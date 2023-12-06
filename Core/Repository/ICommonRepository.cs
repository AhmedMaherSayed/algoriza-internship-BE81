using Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface ICommonRepository<T> : IBaseRepository<T> where T : class
    {
        IActionResult Update(T entity);
        bool IsExist(Expression<Func<T, bool>> criteria);

    }
}
