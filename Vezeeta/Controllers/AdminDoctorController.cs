using Core.DTO;
using Core.Repository;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Migrations;
using System.Reflection.Metadata.Ecma335;

namespace Vezeeta.Controllers
{
    [Route("api/Admin/Doctor")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminDoctorController : ControllerBase
    {
        private readonly IDoctorServices _doctorService;

        public AdminDoctorController(IDoctorServices DoctorService)
        {
            _doctorService = DoctorService;
        }
        [HttpGet]
        public IActionResult GetById([FromForm]int Id)
        {
            if(Id == 0)
            {
                ModelState.AddModelError("Id", "Id is required");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _doctorService.GetSpecificDoctorInfo(Id);
        }

        [HttpGet("~/api/Admin/Doctors")]
        public IActionResult GetAll([FromForm] int page, [FromForm] int pageSize, [FromForm] string? search)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return _doctorService.GetAllDoctorsWithFullInfo(page, pageSize, search);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddDoctor([FromForm] UserDTO userDTO, [FromForm] string Specialize)
        {

            if (string.IsNullOrEmpty(Specialize))
            {
                ModelState.AddModelError("Specialize", "Specialize Is Required");
            }
            if (userDTO.Image == null || userDTO.Image.Length == 0)
            {
                ModelState.AddModelError("userDTO.Image", "Image Is Required");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return await _doctorService.AddDoctor(userDTO, UserRole.Patient, Specialize);

        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateDoctor([FromForm]int id,[FromForm] UserDTO userDTO, [FromForm] string Specialize)
        {
            if (string.IsNullOrEmpty(Specialize))
            {
                ModelState.AddModelError("Specialize", "Specialize Is Required");
            }
            if (userDTO.Image == null || userDTO.Image.Length == 0)
            {
                ModelState.AddModelError("userDTO.Image", "Image Is Required");
            }

            if (id == 0)
            {
                ModelState.AddModelError("Id", "Id Is Required");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            };

            return await _doctorService.UpdateDoctor(id,userDTO, Specialize);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDoctor([FromForm]int id)
        {
            try
            {
                if (id == 0)
                {
                    ModelState.AddModelError("id", "id Is Required");
                }
                else if (id < 0)
                {
                    ModelState.AddModelError("id", "id Is Invalid. Id must be greater than 0");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                };
                return await _doctorService.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while Deleting the Doctor:\n" +
                    $"  {ex.Message} \n  {ex.Message}");
            }
        }       
    }
}
