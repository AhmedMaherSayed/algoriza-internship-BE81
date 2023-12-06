using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDiscountCodeCouponServices
    {
        Task<IActionResult> Add(DiscountCodeCoupon Coupon);
        IActionResult Update(DiscountCodeCoupon Coupon);
        IActionResult Delete(int Id);
        IActionResult Deactivate(int id);
    }
}
