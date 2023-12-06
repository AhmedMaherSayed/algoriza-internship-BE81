using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IDataOperationsRepository<T>:ICommonRepository<T> where T : class
    {
        IActionResult Delete(T entity);
    }
}
