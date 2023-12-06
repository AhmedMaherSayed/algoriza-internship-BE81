using Core.Domain;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class SpecializationRepository(ApplicationDbContext context) : BaseRepository<Specialization>(context), ISpecializationRepository
    {
        public Specialization GetByName(string Specialization)
        {
            return _context.Specializations.FirstOrDefault(s => s.Name == Specialization);
        }

        public IActionResult GetTop5()
        {
            try
            {
                var Top5Specialization = _context.Bookings
                            .Join(
                                _context.Doctors,
                                booking => booking.DoctorId,
                                doctor => doctor.Id,
                                (booking, doctor) => new
                                    {
                                      SpecializationId = doctor.SpecializationId,
                                    }
                                )
                            .Join(
                                 _context.Specializations,
                                 b => b.SpecializationId,
                                 s => s.Id,
                                 (b, s) => new
                                     {
                                         specialization = s.Name,
                                     }
                                 )
                            .GroupBy(s => s.specialization)
                            .Select( s => new
                                {
                                    Specialization = s.Key,
                                    NumberOfBookings = s.Count()
                                }
                            )
                            .Take(5)
                            .ToList();

                return new OkObjectResult(Top5Specialization);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"There is a problem while Getting Top 5 Specialization: \n" +
                    $"{ex.Message} \n {ex.InnerException?.Message}")
                {
                    StatusCode = 500
                };
            }
        } 
    }
}