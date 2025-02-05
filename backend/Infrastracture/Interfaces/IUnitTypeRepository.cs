using Data.Entities;
using Infrastracture.Base;

namespace Infrastracture.Interfaces;

public interface IUnitTypeRepository : IGenericRepository<UnitType>
{
    Task<UnitType?> GetUnitTypesByNameAsync(string name);
}