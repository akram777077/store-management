using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface IDealTypeService : IGenericService<DealType>
{
    Task<DealType?> GetDealTypeByNameAsync(string name);
    Task<bool> IsDealTypeExistsAsync(string name);
    Task<bool> IsDealTypeNameExistsAsync(string name, int id);
}