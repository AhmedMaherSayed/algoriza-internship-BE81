using Core.Domain;
using Core.DTO;
using Core.Repository;
using Core.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repository
{
    public class DoctorRepository : DataOperationsRepository<Doctor>, IDoctorRepository
    {
        private UserManager<ApplicationUser> _userManager;

        public DoctorRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager) : base(context)
        {
            _userManager = userManager;
        }

        public int GetDoctorIdByUserId(string UserId)
        {
            Doctor? doctor = _context.Doctors.FirstOrDefault(d => d.DoctorUserId == UserId);
            return doctor == null ? 0 : doctor.Id;
        }

        public async Task<ApplicationUser> GetDoctorUser(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            return user;
        }

        public async Task<string> GetDoctorIdFromClaim(ApplicationUser user)
        {
            var Claims = await _userManager.GetClaimsAsync(user);
            return Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        }

        public IActionResult GetTop10Doctors()
        {
            try
            {
                var topDoctors = _context.Bookings
                 .GroupBy(b => b.DoctorId)
                 .Select(group => new
                 {
                     DoctorId = group.Key,
                     RequestCount = group.Count()
                 })
                 .OrderByDescending(doctor => doctor.RequestCount)
                 .Take(10)
                 .Join(_context.Doctors,
                     doctor => doctor.DoctorId,
                     d => d.Id,
                     (doctor, d) => new
                     {
                         UserId = d.DoctorUserId,
                         RequestCount = doctor.RequestCount
                     })
                 .Join(_context.Users,
                      d => d.UserId,
                      u => u.Id,
                      (d, u) => new
                      {
                          DoctorName = u.FullName,
                          RequestCount = d.RequestCount
                      })
                 .ToList();

                return new OkObjectResult(topDoctors);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during Getting Top 10 doctors \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public IActionResult GetSpecificDoctorInfo(int doctorId)
        {
            try
            {
                var doctor = _context.Doctors.Where(d=>d.Id==doctorId)
                           .Join
                            (
                                _context.Users,
                                doctor => doctor.DoctorUserId,
                                user => user.Id,
                                (doctor, user) => new
                                {
                                    Image = user.Image,
                                    FullName = user.FullName,
                                    Email = user.Email,
                                    Phone = user.PhoneNumber,
                                    Gender = Enum.GetName(user.Gender),
                                    DateOfBirth = user.DateOfBirth,
                                    SpecializationId = doctor.SpecializationId
                                }
                            ).Join
                            (
                                _context.Specializations,
                                doctor => doctor.SpecializationId,
                                specialization => specialization.Id,
                                (doctor, specialization) => new DoctorDTO
                                {
                                    ImagePath = doctor.Image,
                                    FullName = doctor.FullName,
                                    Email = doctor.Email,
                                    Phone = doctor.Phone,
                                    Gender = doctor.Gender,
                                    BirthOfDate = doctor.DateOfBirth,
                                    Specialization = specialization.Name
                                }
                            ).FirstOrDefault();

                return new OkObjectResult(doctor);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during Getting doctor Info \n" +
                    $"{ex.Message}\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public IActionResult GetAllDoctorsWithFullInfo(int Page, int PageSize,
                                                        Func<DoctorDTO, bool> criteria = null)
        {
            try
            {
                IEnumerable<DoctorDTO> fullDoctorsInfo = _context.Set<Doctor>()
                                            .Join
                                             (
                                                _context.Users,
                                                doctor => doctor.DoctorUserId,
                                                user => user.Id,
                                                (doctor, user) => new
                                                {
                                                    Image = user.Image,
                                                    FullName = user.FullName,
                                                    Email = user.Email,
                                                    Phone = user.PhoneNumber,
                                                    Gender = Enum.GetName(user.Gender),
                                                    SpecializationId = doctor.SpecializationId
                                                }
                                            ).Join
                                            (
                                                _context.Specializations,
                                                doctor => doctor.SpecializationId,
                                                specialization => specialization.Id,
                                                (doctor, specialization) => new DoctorDTO
                                                {
                                                    ImagePath = doctor.Image,
                                                    FullName = doctor.FullName,
                                                    Email = doctor.Email,
                                                    Phone = doctor.Phone,
                                                    Gender = doctor.Gender,
                                                    Specialization = specialization.Name
                                                }
                                            );
                if (criteria == null)
                {
                    fullDoctorsInfo = fullDoctorsInfo.Where(criteria);
                }

                if (Page != 0)
                    fullDoctorsInfo = fullDoctorsInfo.Skip((Page - 1) * PageSize);

                if (PageSize != 0)
                    fullDoctorsInfo = fullDoctorsInfo.Take(PageSize);
                
                return new OkObjectResult(fullDoctorsInfo.ToList());
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem during getting the data {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }

    }
}
