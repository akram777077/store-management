using Core.Featurs.Authorization.Queries.Responses;
using Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        private void GetRolesListMapping()
        {
            CreateMap<Role, GetRoleResponse>();
        }
    }
}
