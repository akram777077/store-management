using Data.Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.ServiceImplementations;

public class InventoryService : GenericService<Inventory>, IInventoryService
{
    private readonly IInventoryRepository _repository;

    public InventoryService(IInventoryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    // Implement your functions here
    public async Task<Inventory?> GetInventoryByLocationAsync(string location)
    {
        return await _repository.GetListAsync()
            .Where(i => EF.Functions.ILike(i.Location, location))
            .FirstOrDefaultAsync();
    }
}