using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.AppMetaData
{
    public static partial class Router
    {
        public static class AuthorizationRouting
        {
            public const string Prefix = "AuthorizationRouting";
            public const string Roles = Prefix + "/Roles";
            public const string Claims = Prefix + "/Claims";
            public const string Create = Roles + "/Create";
            public const string Edit = Roles + "/Edit";
            public const string Delete = Roles + "/Delete/{Id}";
            public const string RolesList = Roles + "/Role-List";
            public const string GetRoleById = Roles + "/Role-By-Id/{Id}";
            public const string GetRoleByName = Roles + "/Role-By-Name/{Name}";
            public const string ManageUserRoles = Roles + "/Manage-User-Roles/{userId}";
            public const string UpdateUserRoles = Roles + "/Update-User-Roles";
            public const string ManageUserClaims = Claims + "/Manage-User-Claims/{userId}";
            public const string UpdateUserClaims = Claims + "/Update-User-Claims";

        }
    }
}
