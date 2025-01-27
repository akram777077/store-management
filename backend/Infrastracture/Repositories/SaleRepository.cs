using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class SaleRepository : GenericRepository<Sale>, ISaleRepository
{
    private readonly DbSet<Sale> _sales;

    public SaleRepository(AppDbContext context) : base(context)
    {
        _sales = context.Sales;
    }

    // Implement your functions here
}