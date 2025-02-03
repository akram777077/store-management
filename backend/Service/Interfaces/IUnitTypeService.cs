using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface IUnitTypeService : IGenericService<UnitType>
{
    Task<UnitType?> GetUnitTypesByNameAsync(string name);
}