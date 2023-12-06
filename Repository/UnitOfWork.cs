using Core.Domain;
using Core.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public IDoctorRepository Doctors { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IDiscountCodeCouponRepository DiscountCodeCoupons { get; private set; }
        public IAppointmentRepository Appointments { get; private set; }
        public IAppointmentTimeRepository AppointmentTimes { get; private set; }
        public IBookingsRepository Bookings { get; private set; }
        public ISpecializationRepository Specializations { get; private set; }
        public IPatientRepository Patients { get; private set; }

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager) {
 
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;

            //Doctor
            Doctors = new DoctorRepository(_context, userManager);
            ApplicationUser = new ApplicationUserRepository(_context, _userManager,
                _roleManager, _signInManager);
            DiscountCodeCoupons = new DiscountCodeCouponRepository(_context);
            Appointments = new AppointmentRepository(_context);
            Bookings = new BookingsRepository(_context);
            Specializations = new SpecializationRepository(_context);
            AppointmentTimes = new AppointmentTimeRepository(_context);  
            Patients = new PatientRepository(_context,_userManager, _roleManager, _signInManager);

        }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
