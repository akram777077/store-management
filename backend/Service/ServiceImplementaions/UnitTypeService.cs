using Data.Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class UnitTypeService : GenericService<UnitType>, IUnitTypeService
{
    #region Fields
    private readonly IUnitTypeRepository _repository;
    #endregion

    #region Constructor
    public UnitTypeService(IUnitTypeRepository repository) : base(repository)
    {
        _repository = repository;
    }
    #endregion

    #region Functions Handling
    // Implement your functions here
    public async Task<UnitType?> GetUnitTypesByNameAsync(string name)
    {
        return await _repository.GetListAsync()
                    .FirstOrDefaultAsync(c => EF.Functions.ILike(c.Name, name));
    }
    public async Task<bool> IsUnitTypeNameExists(string name)
    {
        return await _repository.GetListAsync()
               .AnyAsync(c => EF.Functions.ILike(c.Name, name));
    }
    public async Task<bool> IsUnitTypeNameExists(string name, long id)
    {
        return await _repository.GetListAsync()
                .AnyAsync(c => EF.Functions.ILike(c.Name, name) && c.Id != id);
    }
    #endregion

}