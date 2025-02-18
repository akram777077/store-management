using Core.Featurs.Inventories.Commands.Requests;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Inventories
{


    public partial class InventoryProfile
    {
        private void CreateInventoryMapping()
        {
            CreateMap<CreateInventoryCommand, Inventory>();
        }
    }

    
}
