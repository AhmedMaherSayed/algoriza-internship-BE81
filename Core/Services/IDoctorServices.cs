using Core.DTO;
using Core.Repository;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDoctorServices : IApplicationUserService
    {
        public IActionResult GetTop10();
        IActionResult ConfirmCheckUp(int BookingId);
        Task<IActionResult> AddDoctor(UserDTO userDTO, UserRole patient, string specialize);
        Task<IActionResult> Delete(int id);
        IActionResult AddAppointments(int DoctorId,AppointmentsDTO appointments);
        Task<IActionResult> UpdateDoctor(int id, UserDTO userDTO, string specialize);
        IActionResult GetSpecificDoctorInfo(int id);
         IActionResult GetAllDoctorsWithFullInfo(int Page, int PageSize, string search);

    }
}
