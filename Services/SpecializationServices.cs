using Core.Repository;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection
{
    public class SpecializationServices : ISpecializationServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public SpecializationServices(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public IActionResult GetTop5()
        {
            return _unitOfWork.Specializations.GetTop5();
        }
    }
}