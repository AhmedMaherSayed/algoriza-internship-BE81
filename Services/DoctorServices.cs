using AutoMapper;
using Core.Domain;
using Core.DTO;
using Core.Repository;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DoctorServices: ApplicationUserService, IDoctorServices
    {
        private readonly IAppointmentServices _appointmentServices;

        public DoctorServices(IUnitOfWork UnitOfWork, IMapper mapper,
            IAppointmentServices appointmentServices) : 
            base(UnitOfWork, mapper)
        {
            _appointmentServices = appointmentServices;
        }

        public IActionResult GetTop10()
        {
            return _unitOfWork.Doctors.GetTop10Doctors();
        }
        public IActionResult AddAppointments(int DoctorId, AppointmentsDTO appointments)
        {
            var SettingPriceResult = SetPrice(DoctorId, appointments.Price); 
            if (SettingPriceResult is not OkObjectResult)
            {
                return SettingPriceResult;
            }

            var AddingDayOfWeekResult = _appointmentServices.AddDays(DoctorId, appointments.days);
            if (AddingDayOfWeekResult is not OkResult)
            {
                return AddingDayOfWeekResult;
            }

            _unitOfWork.Complete();
            return new OkObjectResult("Price & Appointments Added Successfully");
        }

        private IActionResult SetPrice(int doctorId, decimal price)
        {
            Doctor doctor = _unitOfWork.Doctors.GetById(doctorId);
            if (doctor == null)
            {
                return new NotFoundObjectResult($"Doctor with id {doctorId} is not found");

            }

            doctor.Price = price;

            var updatingResult = _unitOfWork.Doctors.Update(doctor);
            return updatingResult;
           
        }

        public async Task<IActionResult> AddDoctor(UserDTO userDTO, UserRole patient, string specialize)
        {
            try
            {
                Specialization specialization = _unitOfWork.Specializations.GetByName(specialize);
                if (specialization == null)
                {
                    return new NotFoundObjectResult($"There is no Specialization called {specialize}");
                }

                var result = await AddUser(userDTO, UserRole.Doctor);

                if (result is not OkObjectResult okResult)
                {
                    return result;
                }


                ApplicationUser User = okResult.Value as ApplicationUser;
                Doctor doctor = new()
                {
                    DoctorUser = User,
                    Specialization = specialization,
                };

                await _unitOfWork.Doctors.Add(doctor);
                _unitOfWork.Complete();
                return new OkObjectResult(doctor);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Adding Doctor \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Doctor doctor = _unitOfWork.Doctors.GetById(id);
                if (doctor == null)
                {
                    return new NotFoundObjectResult($"Id {id} is not found");
                }

                _unitOfWork.Doctors.Delete(doctor);
                 ApplicationUser User = await _unitOfWork.Doctors.GetDoctorUser(doctor.DoctorUserId);
                await _unitOfWork.ApplicationUser.DeleteUser(User);
                _unitOfWork.Complete();
                return new OkObjectResult("Deleted successfully");
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }
        }

        public IActionResult ConfirmCheckUp(int BookingId)
        {
            return ChangeBookingState(BookingId, BookingState.Completed);
        }

        public async Task<IActionResult> UpdateDoctor(int id, UserDTO userDTO, string specialize)
        {
            try
            {
                Doctor doctor = _unitOfWork.Doctors.GetById(id);
                if(doctor == null)
                {
                    return new NotFoundObjectResult($"There is no Doctor with id: {id}.");
                }

                Specialization specialization = _unitOfWork.Specializations.GetByName(specialize);
                if (specialization == null)
                {
                    return new NotFoundObjectResult($"There is no Specialization called {specialize}");
                }
                doctor.SpecializationId = specialization.Id;

                ApplicationUser user = await _unitOfWork.ApplicationUser.GetUser(doctor.DoctorUserId);
                var result = await UpdateUser(user, userDTO);

                if (result is not OkResult)
                {
                    return result;
                }

                _unitOfWork.Doctors.Update(doctor);
                _unitOfWork.Complete();
                return new OkObjectResult(doctor);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Adding Doctor \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public IActionResult GetSpecificDoctorInfo(int id)
        {
            try
            {
                bool IfFound = _unitOfWork.Doctors.IsExist(doctor => doctor.Id == id);
                if (!IfFound)
                {
                    return new NotFoundObjectResult($"No doctor found with id {id}");
                }

                var result = _unitOfWork.Doctors.GetSpecificDoctorInfo(id);
                if (result is not OkObjectResult okResult)
                {
                    return result;
                }

                DoctorDTO doctorInfo = okResult.Value as DoctorDTO;
                doctorInfo.Image = GetImage(doctorInfo.ImagePath);
                var CompleteDoctorInfo = new
                {
                    doctorInfo.Image,
                    doctorInfo.FullName,
                    doctorInfo.Email,
                    doctorInfo.Phone,
                    doctorInfo.Gender,
                    doctorInfo.BirthOfDate,
                    doctorInfo.Specialization
                };

                return new OkObjectResult(CompleteDoctorInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Doctor info \n: {ex.Message}" +
                   $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public IActionResult GetAllDoctorsWithFullInfo(int Page, int PageSize, string search)
        {
            try
            {
                Func<DoctorDTO, bool> criteria = null;
                
                if(!string.IsNullOrEmpty(search))
                   criteria = (d => d.Email.Contains(search) ||d.Phone.Contains(search) ||
                               d.FullName.Contains(search) || d.Gender.Contains(search) ||
                               d.Specialization.Contains(search));

                var gettingDoctorsResult = _unitOfWork.Doctors.GetAllDoctorsWithFullInfo(Page, PageSize, criteria);
                if (gettingDoctorsResult is not OkObjectResult doctorsResult)
                {
                    return gettingDoctorsResult;
                }
                List<DoctorDTO> doctorsInfoList = doctorsResult.Value as List<DoctorDTO>;

                var doctorsInfo = doctorsInfoList.Select(d => new 
                {
                    Image = GetImage(d.ImagePath),
                    FullName = d.FullName,
                    Phone = d.Phone,
                    Email = d.Email,
                    Gender = d.Gender,
                    Specialization = d.Specialization
                }).ToList();

                return new OkObjectResult(doctorsInfo);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Getting Doctors info \n: {ex.Message}" +
                    $"\n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
