using Core.Featurs.Inventories.Queries.Response;
using System;
using System.Collections.Generic;
using Data.Entities;

namespace Core.Mapping.Inventories
{
    public partial class InventoryProfile
    {
        private void GetInventoriesMapping()
        {
            CreateMap<Inventory, GetInventoriesResponse>();
        }
    }
}
