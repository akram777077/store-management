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
   
    // Implement your functions here
}