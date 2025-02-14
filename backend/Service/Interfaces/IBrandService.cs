using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface IBrandService : IGenericService<Brand>
{
    Task<Brand?> GetBrandsByNameAsync(string name);
    Task<bool> IsBrandNameExistsAsync(string name);
    Task<bool> IsBrandNameExistsAsync(string name, long Id);
}