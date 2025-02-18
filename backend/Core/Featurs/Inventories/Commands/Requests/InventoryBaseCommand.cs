using Core.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Inventories.Commands.Requests
{
    public class InventoryBaseCommand : IRequest<Response<string>>
    {
        public required string Location { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdate = DateTime.UtcNow;
    }
}
