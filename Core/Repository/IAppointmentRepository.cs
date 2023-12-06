using Core.Domain;
using Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DayOfWeek = Core.Utilities.DayOfWeek;

namespace Core.Repository
{
    public interface IAppointmentRepository:ICommonRepository<Appointment>
    {
        Appointment GetByDoctorIdAndDay(int doctorId, DayOfWeek day);
    }
}
