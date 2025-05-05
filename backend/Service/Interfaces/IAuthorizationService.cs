using Data.Entities.Identity;
using Data.Requests;
using Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IAuthorizationService
    {
        public Task<List<Role>> GetRolesList();
        public Task<ManageUserRolesResult> GetRolesOfUsuer(User user);
        public Task<Role> GetRolesById(string Id);
        public Task<Role> GetRolesByName(string Name);
        public Task<string> AddRole(string roleName);
        public Task<string> DeleteRole(string roleName);
        public Task<string> EditRole(EditRoleRequest editRoleRequest);
        public Task<string> ManageUserRole(UpdateUserRoleRequest request);
        public Task<string> ManageUserClaims(UpdateUserClaimsResquest request);
        public Task<bool> IsRoleExists(string roleName);
        public Task<bool> IsRoleExists(string roleName, string Id);
        Task<ManageUserClaimsResult> ManageUserClaimData(User user);
    }
}
