using Core.Domain;
using Core.Repository;
using Core.Services;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AppointmentTimeServices : IAppointmentTimeServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentTimeServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private IActionResult AddDayTime(int dayId, TimeSpan timeSlot)
        {
            AppointmentTime appointmentTime;
            if (dayId > 0)
            {
                appointmentTime = _unitOfWork.AppointmentTimes.GetByDayIdAndSlot(dayId, timeSlot);

                if (appointmentTime != null)
                {
                    return new OkResult();
                }
            }

            appointmentTime = new AppointmentTime()
            {
                Time = timeSlot
            };
            return new OkObjectResult(appointmentTime);

        }
        public IActionResult AddDayTimes(int dayId, List<string> Times)
        {    
            if(Times.Count == 0)
            {
                return new BadRequestObjectResult("Times is required");
            }

            List<AppointmentTime> dayTimes = new List<AppointmentTime>();
            IActionResult result;
            TimeSpan timeSlot;
            foreach (var time in Times)
            {
                timeSlot = ConvertStringTotTimeSpan(time);
                result = AddDayTime(dayId, timeSlot);
                if (result is not OkObjectResult okObject)
                {
                    continue;
                }
                dayTimes.Add(okObject.Value as AppointmentTime);
            }

            return new OkObjectResult(dayTimes);
        }

        public TimeSpan ConvertStringTotTimeSpan(string strTime)
        { 
            return Convert.ToDateTime(strTime).TimeOfDay; ;
        }

        public IActionResult DeleteAppointment(int TimeId)
        {
            try
            {
                AppointmentTime appointmentTime = _unitOfWork.AppointmentTimes.GetById(TimeId);
                if (appointmentTime == null)
                {
                    return new NotFoundObjectResult($"There is no appointment time with id {TimeId}");
                }

                bool IsUsed = _unitOfWork.Bookings.IsExist(b => b.AppointmentTimeId == TimeId);
                if (IsUsed)
                {
                    return new BadRequestObjectResult($"Can't delete appointment time with id {TimeId} " +
                        "has already been used");
                }

                _unitOfWork.AppointmentTimes.Delete(appointmentTime);
                _unitOfWork.Complete();
                return new OkObjectResult($"appointment time with id {TimeId} has been deleted successfully");
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while deleting appointmentTime: \n " +
                    $"{ex.Message} \n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }

        public IActionResult UpdateAppointment(int TimeId, string NewTime)
        {
            try
            {
                AppointmentTime appointmentTime = _unitOfWork.AppointmentTimes.GetById(TimeId);
                if (appointmentTime == null)
                {
                    return new NotFoundObjectResult($"There is no appointment time with id {TimeId}");
                }

                bool IsUsed = _unitOfWork.Bookings.IsExist(b => b.AppointmentTimeId == TimeId &&
                (b.BookingState == BookingState.Pending || b.BookingState == BookingState.Completed) );
                if (IsUsed)
                {
                    return new BadRequestObjectResult($"Can't delete appointment time with id {TimeId} " +
                        "has already been used");
                }

                appointmentTime.Time = ConvertStringTotTimeSpan(NewTime);

                bool IsSimilarExist = _unitOfWork.AppointmentTimes.IsExist(at => 
                                at.AppointmentId == appointmentTime.AppointmentId &&
                                at.Time == appointmentTime.Time); 

                if (IsSimilarExist)
                {
                    return new BadRequestObjectResult("This time is already exists.");
                }

                _unitOfWork.AppointmentTimes.Update(appointmentTime);
                _unitOfWork.Complete();
                return new OkObjectResult(appointmentTime);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while deleting appointmentTime: \n " +
                    $"{ex.Message} \n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        }


    }
}
