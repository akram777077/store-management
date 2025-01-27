using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class SaleTypeRepository : GenericRepository<SaleType>, ISaleTypeRepository
{
    private readonly DbSet<SaleType> _saleTypes;

    public SaleTypeRepository(AppDbContext context) : base(context)
    {
        _saleTypes = context.SaleTypes;
    }

    // Implement your functions here
}