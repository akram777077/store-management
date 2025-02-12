using Data.Entities;
using Infrastracture.Base;

namespace Infrastracture.Interfaces;

public interface IBrandRepository : IGenericRepository<Brand>
{
    public Task<Brand?> GetBrandByNameAsync(string name);
}