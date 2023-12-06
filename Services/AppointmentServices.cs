using Core.Domain;
using Core.DTO;
using Core.Repository;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOfWeek = Core.Utilities.DayOfWeek;

namespace Services
{
    public class AppointmentServices : IAppointmentServices
    {
        private readonly IAppointmentTimeServices _timeServices;
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentServices(IAppointmentTimeServices timeServices, IUnitOfWork unitOfWork)
        {
            _timeServices = timeServices;
            _unitOfWork = unitOfWork;
        }

        public IActionResult AddDays(int doctorId, List<Day> appointments)
        {
            IActionResult result;
            foreach (var day in appointments)
            {
                result = AddDay(doctorId, day);
                if (result is not OkResult)
                {
                    return result;
                }
            }
            return new OkResult();
        }

        private IActionResult ConvertStringToDayOfWeek(string day)
        {
            DayOfWeek DayOfWeek;
            if (Enum.TryParse(day, true, out DayOfWeek))
            {
                return new OkObjectResult(DayOfWeek);
            }
            else
            {
                return new BadRequestObjectResult("Day is invalid");
            }
        }
        private IActionResult AddDay(int doctorId, Day Day)
        {
            if (Day.Times == null)
            {
                return new BadRequestObjectResult($"Inter Time Slots for day {Day.day}");
            }

            var result = ConvertStringToDayOfWeek(Day.day);

            if (result is not OkObjectResult okResult)
            {
                return result;
            }
            DayOfWeek DayOfWeek = (DayOfWeek)okResult.Value;

            Appointment appointment = _unitOfWork.Appointments.GetByDoctorIdAndDay(doctorId, DayOfWeek);
            int DayId = 0;
            if (appointment == null)
            {
                appointment = new Appointment()
                {
                    DoctorId = doctorId,
                    DayOfWeek = DayOfWeek,
                };
            }
            else
            {
                DayId = appointment.Id;
            }
          
            IActionResult addingDayTimesResult = _timeServices.AddDayTimes(DayId, Day.Times);
            if (addingDayTimesResult is not OkObjectResult addingTimesResult)
            {
                return addingDayTimesResult;
            }

            var addingTimesList = (List<AppointmentTime>)addingTimesResult.Value;
            if(addingTimesList.Count == 0)
            {
                return new OkResult();
            }
            appointment.AppointmentTimes = addingTimesList; 

            try
            {
                if (DayId == 0)
                {
                    _unitOfWork.Appointments.Add(appointment);
                }
                else
                {
                    _unitOfWork.Appointments.Update(appointment);
                }
                return new OkResult();
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"There is a problem while Adding {Day} \n {ex.Message}" +
                     $"\n {ex.InnerException?.Message}");
            }
        }
    }
}
