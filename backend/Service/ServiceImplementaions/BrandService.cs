using Data.Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class BrandService : GenericService<Brand>, IBrandService
{
    #region Fields
    private readonly IBrandRepository _repository;
    #endregion

    #region Constructor
    public BrandService(IBrandRepository repository) : base(repository)
    {
        _repository = repository;
    }
    #endregion

    #region Functions Handling
    public async Task<Brand?> GetBrandsByNameAsync(string name)
    {
        return await _repository.GetListAsync()
            .FirstOrDefaultAsync(c => EF.Functions.ILike(c.Name, name));
    }

    public async Task<bool> IsBrandNameExistsAsync(string name)
    {
        return await _repository.GetListAsync()
                   .AnyAsync(c => EF.Functions.ILike(c.Name, name));
    }

    public async Task<bool> IsBrandNameExistsAsync(string name, long id)
    {
        return await _repository.GetListAsync()
                   .AnyAsync(c => EF.Functions.ILike(c.Name, name) && c.Id != id);
    }
    #endregion

    // Implement your functions here
}