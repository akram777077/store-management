using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Data.Healper
{
    public static class ClaimStore
    {
        public static List<Claim> Claims = new()
        {
            new Claim("RetriveInventoryDetailsLists","false"),
            new Claim("CreateInventoryDetails","false"),
            new Claim("EditInventoryDetails","false"),
            new Claim("DeleteInventoryDetails","false"),
        };
    }
}
