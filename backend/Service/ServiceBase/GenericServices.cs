using Infrastracture.Base;
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

        // Add multiple entities
        public async Task AddRangeAsync(ICollection<T> entities)
        {
            await _repository.AddRangeAsync(entities);
        }

        // Get by Id
        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // Get all entities with no tracking
        public IQueryable<T> GetTableNoTracking()
        {
            return _repository.GetTableNoTracking();
        }

        // Get all entities with tracking
        public IQueryable<T> GetTableAsTracking()
        {
            return _repository.GetTableAsTracking();
        }

        // Update a single entity
        public async Task UpdateAsync(T entity)
        {
            await _repository.UpdateAsync(entity);
        }

        // Update multiple entities
        public async Task UpdateRangeAsync(ICollection<T> entities)
        {
            await _repository.UpdateRangeAsync(entities);
        }

        // Delete a single entity
        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

        // Delete multiple entities
        public async Task DeleteRangeAsync(ICollection<T> entities)
        {
            await _repository.DeleteRangeAsync(entities);
        }

        // Commit changes
        public void Commit()
        {
            _repository.Commit();
        }

        // Rollback changes
        public void RollBack()
        {
            _repository.RollBack();
        }

        // Save changes
        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }

        // Begin a transaction
        public IDbContextTransaction BeginTransaction()
        {
            return _repository.BeginTransaction();
        }

        #endregion
    }

}
