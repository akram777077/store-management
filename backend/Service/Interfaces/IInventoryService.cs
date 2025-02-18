using Data.Entities;
using ServiceLayer.ServiceBase;

namespace ServiceLayer.Interfaces;

public interface IInventoryService : IGenericService<Inventory>
{
    Task<Inventory?> GetInventoryByLocationAsync(string location);
    Task<bool> IsInventoryLocationIsExists(string location);
    Task<bool> IsInventoryLocationIsExists(string location, long id);

}