using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface IDealTypeService : IGenericService<DealType>
{
    Task<DealType?> GetDealTypeByNameAsync(string name);
}