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
    public class CommonRepository<T> : BaseRepository<T>, ICommonRepository<T> where T : class
    {
        public CommonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public bool IsExist(Expression<Func<T, bool>> criteria) 
        {
            return _context.Set<T>().Any(criteria);
        }
        public IActionResult Update(T entity)
        {
            try
            {
                _context.Update(entity);
                return new OkObjectResult(entity);
            }
            catch (Exception ex)
            {
                return new ObjectResult($"An error occurred while Deleting \n: {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }
    }
}
