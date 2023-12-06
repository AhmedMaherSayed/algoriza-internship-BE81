using Core.Domain;
using Core.DTO;
using Core.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IApplicationUserService
    {
        Task<IActionResult> AddUser(UserDTO userDTO, UserRole userRole);
        Task<IActionResult> GetUsersCountInRole(string roleName);
        Task<IActionResult> SignIn(string Email, String Password, bool RememberMe);
        Task SignOut();
        IActionResult ChangeBookingState(int BookingId, BookingState bookingState);
        Task<IActionResult> UpdateUser(ApplicationUser CurrentUser, UserDTO userDTO);
    }
}
