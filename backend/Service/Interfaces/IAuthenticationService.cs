using Data.Entities.Identity;
using Data.Results;
using ServiceLayer.Healpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<JwtAuthResult> GetJWTToken(User user);
        public JwtSecurityToken ReadJwtToken(string accessToken);
        public string ValidateToken(string accessToken);
        public Task<TokenValidationResponse> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken);
        public JwtAuthResult GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? ExpiryDate, string refreshToken);


    }
}
