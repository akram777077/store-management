using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class PricingRepository : GenericRepository<Pricing>, IPricingRepository
{
    private readonly DbSet<Pricing> _pricings;

    public PricingRepository(AppDbContext context) : base(context)
    {
        _pricings = context.Pricings;
    }

    // Implement your functions here
}