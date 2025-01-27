using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class InventoryDetailRepository : GenericRepository<InventoryDetail>, IInventoryDetailRepository
{
    private readonly DbSet<InventoryDetail> _inventoryDetails;

    public InventoryDetailRepository(AppDbContext context) : base(context)
    {
        _inventoryDetails = context.InventoryDetails;
    }

    // Implement your functions here
}