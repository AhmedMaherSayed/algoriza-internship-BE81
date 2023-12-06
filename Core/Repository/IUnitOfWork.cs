using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public IDoctorRepository Doctors { get; }
        public IApplicationUserRepository ApplicationUser { get; }
        public IDiscountCodeCouponRepository DiscountCodeCoupons { get; }
        public IAppointmentTimeRepository AppointmentTimes { get; }
        public IAppointmentRepository Appointments { get; }
        public IBookingsRepository Bookings { get; }
        public ISpecializationRepository Specializations { get; }
        public IPatientRepository Patients { get; }
        int Complete();
    }
}
