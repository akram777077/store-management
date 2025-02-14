using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class DealTypeRepository : GenericRepository<DealType>, IDealTypeRepository
{
    private readonly DbSet<DealType> _dealTypes;

    public DealTypeRepository(AppDbContext context) : base(context)
    {
        _dealTypes = context.DealTypes;
    }

    public async Task<DealType?> GetDealTypeByNameAsync(string name)
    {
        return await _dealTypes.FirstOrDefaultAsync(x => x.Name == name);
    }

    // Implement your functions here
}