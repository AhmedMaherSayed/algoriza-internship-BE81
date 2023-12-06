using Core.Domain;
using System.Linq.Expressions;

namespace Core.Repository
{
    public interface IBookingsRepository: ICommonRepository<Booking>
    {
        int NumOfBooKings();
        int NumOfBookings(Expression<Func<Booking, bool>> criteria);
    }
}
