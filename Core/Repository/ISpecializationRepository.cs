using Core.Domain;
using Microsoft.AspNetCore.Mvc;


namespace Core.Repository
{
    public interface ISpecializationRepository: IBaseRepository<Specialization>
    {
        Specialization GetByName(string Specialization);
        IActionResult GetTop5();
    }
}
