using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class BrandRepository : GenericRepository<Brand>, IBrandRepository
{
    private readonly DbSet<Brand> _brands;

    public BrandRepository(AppDbContext context) : base(context)
    {
        _brands = context.Brands;
    }
    
    public async Task<Brand?> GetBrandByNameAsync(string name)
    {
        return await _brands.FirstOrDefaultAsync(x => x.Name == name);
    }

    // Implement your functions here
}