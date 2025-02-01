using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceBase
{
    public interface IGenericService<T> where T : class
    {
        Task<T> AddAsync(T entity);
        Task<T?> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetListAsync();
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }

}
