using Data.Entities;
using Infrastracture.Data;
using Infrastracture.Base;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Repositories;

public class InventoryRepository : GenericRepository<Inventory>, IInventoryRepository
{
    private readonly DbSet<Inventory> _inventories;

    public InventoryRepository(AppDbContext context) : base(context)
    {
        _inventories = context.Inventories;
    }

    // Implement your functions here
}