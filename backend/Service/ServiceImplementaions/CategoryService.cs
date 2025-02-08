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
    public async Task<Category?> GetCategoryByName(string name)
    {
        return await _repository.GetListAsync()
        .Where(c => EF.Functions.ILike(c.Name, name))
        .FirstOrDefaultAsync();
    }
    public async Task<bool> IsCategoryNameExists(string name)
    {
         return await _repository.GetListAsync()
                .AnyAsync(c => EF.Functions.ILike(c.Name, name));
    }

    public async Task<bool> IsCategoryNameExists(string name, long id)
    {
        return await _repository.GetListAsync()
                .AnyAsync(c => EF.Functions.ILike(c.Name, name) && c.Id != id);
    }

    #endregion
}
