using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface ISaleTypeService : IGenericService<SaleType>
{
    public Task<SaleType?> GetSaleTypeByName(string name);
    public Task<bool> IsSaleTypeNameExists(string name);
    public Task<bool> IsSaleTypeNameExists(string name, long id);
}