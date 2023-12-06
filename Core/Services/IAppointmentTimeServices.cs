using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAppointmentTimeServices
    {
        IActionResult AddDayTimes(int dayId, List<String> value);
        IActionResult DeleteAppointment(int TimeId);
        IActionResult UpdateAppointment(int TimeId, string NewTime);
    }
}
