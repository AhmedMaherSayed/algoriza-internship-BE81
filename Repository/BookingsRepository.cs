using Core.Domain;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookingsRepository : CommonRepository<Booking>, IBookingsRepository
    {
        public BookingsRepository(ApplicationDbContext context) : base(context)
        {

        }

        public int NumOfBookings(Expression<Func<Booking, bool>> criteria)
        {
            return _context.Bookings.Count(criteria);
        }

        public int NumOfBooKings()
        {
            return _context.Bookings.Count();
        }

    }
}
