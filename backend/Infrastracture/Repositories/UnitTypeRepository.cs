using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class UnitTypeRepository : GenericRepository<UnitType>, IUnitTypeRepository
{
    private readonly DbSet<UnitType> _unitTypes;

    public UnitTypeRepository(AppDbContext context) : base(context)
    {
        _unitTypes = context.UnitTypes;
    }

    // Implement your functions here
    public async Task<UnitType?> GetUnitTypesByNameAsync(string name)
    {
        return await _unitTypes
            .AsNoTracking()
            .Include(x => x.Products)
            .FirstOrDefaultAsync(u => u.Name == name);
    }
}