using Core.Domain;
using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DiscountCodeCouponRepository : DataOperationsRepository<DiscountCodeCoupon>, IDiscountCodeCouponRepository
    {
        public DiscountCodeCouponRepository(ApplicationDbContext context) : base(context)
        {
        }

        public DiscountCodeCoupon GetByName(string CouponName)
        {
            return _context.DiscountCodeCoupons.FirstOrDefault(s => s.Name == CouponName);
        }
    }
}
