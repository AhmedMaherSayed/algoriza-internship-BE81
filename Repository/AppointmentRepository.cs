using Core.Domain;
using Core.Repository;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOfWeek = Core.Utilities.DayOfWeek;

namespace Repository
{
    public class AppointmentRepository(ApplicationDbContext context) :
            CommonRepository<Appointment>(context), IAppointmentRepository
    {
        public Appointment? GetByDoctorIdAndDay(int doctorId, DayOfWeek day)
        {
            return _context.Appointments.FirstOrDefault(a => a.DoctorId == doctorId && a.DayOfWeek == day);
        }

    }
}
