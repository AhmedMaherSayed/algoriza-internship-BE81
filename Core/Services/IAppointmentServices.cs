using Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IAppointmentServices
    {
        IActionResult AddDays(int doctorId, List<Day> appointments);
    }
}
