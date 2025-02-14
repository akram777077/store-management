using Data.Entities;
using Infrastracture.Base;

namespace Infrastracture.Interfaces;

public interface IDealTypeRepository : IGenericRepository<DealType>
{
    public Task<DealType?> GetDealTypeByNameAsync(string name);
}