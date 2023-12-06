using Core.Domain;
using Core.Repository;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DiscountCodeCouponServices : IDiscountCodeCouponServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DiscountCodeCouponServices(IUnitOfWork UnitOfWork) {
            _unitOfWork = UnitOfWork;
        }

        public async Task<IActionResult> Add(DiscountCodeCoupon Coupon)
        {
            try
            {
                Coupon.Id = 0;
                var result = await _unitOfWork.DiscountCodeCoupons.Add(Coupon);

                _unitOfWork.Complete();
                return result;
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message} \n {ex.InnerException?.Message}");
            }
        }

        public IActionResult Deactivate(int id)
        {
            try
            {
                DiscountCodeCoupon coupon = _unitOfWork.DiscountCodeCoupons.GetById(id);
                if (coupon == null)
                {
                    return new NotFoundObjectResult($"Id {id} is not found");
                }

                coupon.IsActivated = false;
                var result = _unitOfWork.DiscountCodeCoupons.Update(coupon);

                _unitOfWork.Complete();
                return result;
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message} \n {ex.InnerException?.Message}");
            }
        }

        public IActionResult Delete(int Id)
        {
            try
            {
                DiscountCodeCoupon coupon = _unitOfWork.DiscountCodeCoupons.GetById(Id);
                if (coupon == null)
                {
                    return new NotFoundObjectResult($"Id {Id} is not found");
                }

                var result = _unitOfWork.DiscountCodeCoupons.Delete(coupon);
                _unitOfWork.Complete();
                return result;
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message} \n {ex.InnerException?.Message}");
            }
        }

        public IActionResult Update(DiscountCodeCoupon Coupon)
        {
            try
            {
                bool IsCouponExist = _unitOfWork.DiscountCodeCoupons.IsExist(c => c.Id == Coupon.Id);
                if (!IsCouponExist)
                {
                    return new NotFoundObjectResult($"Id {Coupon.Id} is not found");
                }
                var result = _unitOfWork.DiscountCodeCoupons.Update(Coupon);

                _unitOfWork.Complete();
                return result;
            }
            catch (Exception ex)
            {

                return new BadRequestObjectResult($"{ex.Message} \n {ex.InnerException?.Message}");
            }
        }

    }
}
