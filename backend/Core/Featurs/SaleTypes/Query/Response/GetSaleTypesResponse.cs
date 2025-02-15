using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.SaleTypes.Query.Response
{
    public class GetSaleTypesResponse
    {
        public long Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }

    }
}
