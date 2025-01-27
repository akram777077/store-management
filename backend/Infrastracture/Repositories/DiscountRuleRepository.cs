using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class DiscountRuleRepository : GenericRepository<DiscountRule>, IDiscountRuleRepository
{
    private readonly DbSet<DiscountRule> _discountRules;

    public DiscountRuleRepository(AppDbContext context) : base(context)
    {
        _discountRules = context.DiscountRules;
    }

    // Implement your functions here
}