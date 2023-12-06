using Core.Domain;
using Core.Repository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class PatientRepository : ApplicationUserRepository, IPatientRepository
    {
        public PatientRepository(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager) : 
            base(context, userManager, roleManager, signInManager)
        {
        }
    }
}
