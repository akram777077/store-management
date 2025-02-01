using Infrastracture.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceBase
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        #region Methods

        // Add a single entity
        public async Task<T> AddAsync(T entity)
        {
            return await _repository.AddAsync(entity);
        }

        // Get by Id
        public async Task<T?> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }


        // Update a single entity
        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        
        // Delete a single entity
        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        public async Task<IEnumerable<T>> GetListAsync()
        {
            return await _repository.GetTableNoTracking().ToListAsync();
        }

        #endregion
    }

}
