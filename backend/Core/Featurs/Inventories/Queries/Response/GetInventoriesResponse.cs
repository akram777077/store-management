using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Inventories.Queries.Response
{
    public class GetInventoriesResponse
    {
        public int Id { get; set; }
        public required string Location { get; set; }
        public int Quantity { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
