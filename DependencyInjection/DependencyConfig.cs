using System.Globalization;
using AutoMapper;
using Core.Domain;
using Core.Repository;
using Core.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Services;
using Services.Helpers;

namespace DependencyInjection
{
    public static class DependencyConfig
    {
        public static IServiceCollection ConfigureDependencies(IServiceCollection Services)
        {
            Services.AddControllers();
            Services.AddEndpointsApiExplorer();

            Services.AddIdentity<ApplicationUser, IdentityRole>(
                options => options.Password.RequireDigit = true
                ).
                AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddTransient<IUnitOfWork, UnitOfWork>();
            Services.AddTransient<IApplicationUserService, ApplicationUserService>();
            Services.AddTransient<IAppointmentTimeServices, AppointmentTimeServices>();
            Services.AddTransient<IAppointmentServices, AppointmentServices>();
            Services.AddTransient<IPatientServices, PatientServices>();
            Services.AddTransient<IDoctorServices, DoctorServices>();
            Services.AddTransient<IBookingsServices, BookingsServices>();
            Services.AddTransient<IDiscountCodeCouponServices, DiscountCodeCouponServices>();
            Services.AddTransient<ISpecializationServices, SpecializationServices>();

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingUserDtTOProfile>();
            });
            IMapper _mapper = mapperConfig.CreateMapper();
            Services.AddSingleton(_mapper);

            Services.AddControllers().AddNewtonsoftJson();
            return Services;
        }
    }
}
