using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface IBrandService : IGenericService<Brand>
{
    public Task<Brand?> GetBrandByNameAsync(string name);
}