using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Results
{
    public class ManageUserRolesResult
    {
        public string UserId { get; set; }
        public List<Roles> Roles { get; set; } = new();
    }
    public class Roles
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool HasRole { get; set; }
    }
}
