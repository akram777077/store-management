using Data.Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class SaleTypeService : GenericService<SaleType>, ISaleTypeService
{
    private readonly ISaleTypeRepository _repository;

    public SaleTypeService(ISaleTypeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<SaleType?> GetSaleTypeByName(string name)
    {
        return await _repository.GetListAsync()
            .FirstOrDefaultAsync(c => EF.Functions.ILike(c.Name, name));
    }

    public async Task<bool> IsSaleTypeNameExists(string name)
    {
        return await _repository.GetListAsync()
              .AnyAsync(c => EF.Functions.ILike(c.Name, name));
    }

    public async Task<bool> IsSaleTypeNameExists(string name, long id)
    {
        return await _repository.GetListAsync()
           .AnyAsync(c => EF.Functions.ILike(c.Name, name) && c.Id != id);
    }

    // Implement your functions here
}