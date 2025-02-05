using Data.Entities;
using Infrastracture.Interfaces;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class UnitTypeService : GenericService<UnitType>, IUnitTypeService
{
    private readonly IUnitTypeRepository _repository;

    public UnitTypeService(IUnitTypeRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
    public async Task<UnitType?> GetUnitTypesByNameAsync(string name)
    {
        return await _repository.GetUnitTypesByNameAsync(name);
    }
}