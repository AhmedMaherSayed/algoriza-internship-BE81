using Core.Domain;
using Core.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IDoctorRepository : IDataOperationsRepository<Doctor>
    {
        public IActionResult GetTop10Doctors();
        int GetDoctorIdByUserId(string UserId);
        Task<ApplicationUser> GetDoctorUser(string userId);
        Task<string> GetDoctorIdFromClaim(ApplicationUser user);
        IActionResult GetSpecificDoctorInfo(int doctorId);
        IActionResult GetAllDoctorsWithFullInfo(int Page, int PageSize, 
                                                Func<DoctorDTO, bool> criteria = null);
    }
}
