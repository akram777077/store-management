using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class DealTypeService : GenericService<DealType>, IDealTypeService
{
    private readonly IDealTypeRepository _repository;

    public DealTypeService(IDealTypeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<DealType?> GetDealTypeByNameAsync(string name)
    {
        return await _repository.GetDealTypeByNameAsync(name);
    }

    public async Task<bool> IsDealTypeExistsAsync(string name)
    {
        return await _repository.GetListAsync()
               .AnyAsync(c => EF.Functions.ILike(c.Name, name));
    }



    // Implement your functions here
}