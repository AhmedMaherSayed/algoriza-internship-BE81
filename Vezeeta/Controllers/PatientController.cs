using AutoMapper;
using Core.Domain;
using Core.DTO;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using Services;
using System.Security.Claims;
using System.Text.RegularExpressions;


namespace Vezeeta.Controllers
{
    [Route("api/Patient")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPatientServices _patientServices;
        private readonly IBookingsServices _bookingsServices;
        public PatientController(IPatientServices PatientServices, 
            IBookingsServices bookingsServices) {
            _patientServices = PatientServices;
            _bookingsServices = bookingsServices;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> SignUp([FromForm] UserDTO userDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };

                return await _patientServices.AddUser(userDTO, UserRole.Patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the patient: {ex.Message}");
            }
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromForm] string Email, [FromForm] string Password, [FromForm] bool RememberMe)
        {
            if(string.IsNullOrEmpty(Email))
            {
                ModelState.AddModelError("Email", "Email is required");
            }

            if (string.IsNullOrEmpty(Password))
            {
                ModelState.AddModelError("Password","Password is required");
            }

            string pattern = ".+@.+\\.com";
            bool isMatch = Regex.IsMatch(Email, pattern);

            if (!isMatch)
            {
                ModelState.AddModelError("Email", "Invalid Email");
            }

            if (! ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return await _patientServices.SignIn(Email, Password, RememberMe);
        }

        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _patientServices.SignOut();
            return Ok("LogOut Successfully");
        }

        [HttpPatch("Booking/Cancel")]
        [Authorize(Roles = "Patient")]
        public IActionResult CancelBooking([FromForm]int BookingId)
        {
            return _patientServices.CancelBooking(BookingId);
        }

        [HttpPost("Booking")]
        [Authorize(Roles = "Patient")]
        public IActionResult AddBooking([FromForm]int TimeId, [FromForm]string? CouponName)
        {

            if (TimeId == 0)
            {
                ModelState.AddModelError("TimeId", "TimeId is required");
            }
            else if (TimeId  < 0)
            {
                ModelState.AddModelError("TimeId", "TimeId is invalid");
            }
            string? PatientId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return _bookingsServices.AddBookingToPatient(PatientId,TimeId,CouponName);
        }
    }
}

//{
//  "firstName": "ahmed",
//  "lastName": "maher",
//  "email": "ahmedmaher.maher61@gmail.com",
//  "password": "ahmed1234@",
//  "phone": "0123456",
//  "gender": 1,
//  "dateOfBirth": "2001-05-08",
//  "rememberMe": true
//}