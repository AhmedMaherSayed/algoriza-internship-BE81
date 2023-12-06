using Core.Domain;
using Core.Repository;
using Core.Services;
using Core.Utilities;
using DependencyInjection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Migrations;
using Services;

namespace Vezeeta.Controllers
{
    [Route("api/admin/statistics")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminStatisticsController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        private readonly IBookingsServices _bookingsServices;
        private readonly IDoctorServices _doctorServices;
        private readonly ISpecializationServices _specializationServices;

        public AdminStatisticsController(IApplicationUserService ApplicationUserService, 
            IBookingsServices bookingsServices,IDoctorServices doctorServices,
            ISpecializationServices specializationServices)
        {
            _applicationUserService = ApplicationUserService;
            _bookingsServices = bookingsServices;
            _doctorServices = doctorServices;
            _specializationServices = specializationServices;
        }
        
        [HttpGet("Doctors")]
        public IActionResult GetNumberOfDoctors()
        {
            string? Role = Enum.GetName(UserRole.Doctor);
            return _applicationUserService.GetUsersCountInRole(Role).Result;
        }

        [HttpGet("Patients")]
        public IActionResult GetNumberOfPatients()
        {
            string? Role = Enum.GetName(UserRole.Patient);

            return _applicationUserService.GetUsersCountInRole(Role).Result;
        }

        [HttpGet("Bookings")]
        public IActionResult GetNumberOfBookings()
        {
            return  _bookingsServices.NumOfBookings();
        }

        [HttpGet("Doctor/Top10")]
        public IActionResult GetTop10Doctors()
        {
            return _doctorServices.GetTop10();
        }

        [HttpGet("Specialization/Top5")]
        public IActionResult GetTop5Specialization()
        {
            return _specializationServices.GetTop5();
        }
    }
}
