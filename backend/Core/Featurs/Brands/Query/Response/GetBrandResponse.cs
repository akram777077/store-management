using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Brands.Query.Response
{
    public class GetBrandResponse
    {
        public long Id { get; set; }
        public required string Name { get; set; }
    }
}
