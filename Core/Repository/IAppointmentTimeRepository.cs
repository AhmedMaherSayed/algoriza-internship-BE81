using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IAppointmentTimeRepository : IDataOperationsRepository<AppointmentTime>
    {
        AppointmentTime GetByDayIdAndSlot(int dayId, TimeSpan timeSlot);
    }
}
