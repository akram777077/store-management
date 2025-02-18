using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Inventories.Commands.Requests
{
    public class UpdateInventoryCommand : InventoryBaseCommand
    {
        public long Id { get; set; }
    }
}
