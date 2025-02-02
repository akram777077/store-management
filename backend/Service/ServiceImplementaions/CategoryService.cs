using Data.Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;
public class CategoryService : GenericService<Category>, ICategoryService
{
    #region Fields
    private readonly ICategoryRepository _repository;
    #endregion

    #region Constructor
    public CategoryService(ICategoryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    #endregion

    #region Functions Handling
    //implement your functions here
    public async Task<bool> IsCategoryNameExists(string name)
    {
         return await _repository.GetTableNoTracking()
                .AnyAsync(s => s.Name.Equals(name));
    }
    public async Task<Category> GetCategoryByName(string name)
    {
        return await _repository.GetTableNoTracking()
                .FirstOrDefaultAsync(s => s.Name.Equals(name));
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public Task<bool> IsCategoryNameExists(string name, int id)
    {
        return _repository.GetTableNoTracking()
                .AnyAsync(s => s.Name.Equals(name) && s.Id != id);
    }

    #endregion
}
