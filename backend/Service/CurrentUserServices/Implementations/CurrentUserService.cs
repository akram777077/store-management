using Data.Entities.Identity;
using Data.Healper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ServiceLayer.CurrentUserServices.Interfaces;
using System.Security.Claims;

namespace Service.CurrentUserServices.Implementations
{
    public class CurrentUserService : ICurrentUserService
    {
        #region Fields
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructors
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        #endregion
        #region Functions
        private string GetUserId()
        {
            var userIdClaim = _httpContextAccessor.HttpContext.User.Claims
                .SingleOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdClaim?.Value))
            {
                throw new UnauthorizedAccessException();
            }

            return userIdClaim.Value;
        }

        public async Task<User> GetCurrentUserAsync()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            { throw new UnauthorizedAccessException(); }
            return user;
        }

        public async Task<List<string>> GetCurrentUserRolesAsync()
        {
            var user = await GetCurrentUserAsync();
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
        #endregion
    }
}
