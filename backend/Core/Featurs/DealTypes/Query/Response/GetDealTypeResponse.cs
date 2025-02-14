using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.DealTypes.Query.Response
{
    public class GetDealTypeResponse
    {
        public long Id { get; set; }
        public required string Name { get; set; }
    }
}
