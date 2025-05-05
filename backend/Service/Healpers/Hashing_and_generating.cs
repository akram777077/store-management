using Data.Entities.Identity;
using Data.Healper;
using Data.Results;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Healpers
{
    public static class Hashing_and_generating
    {
        public static List<Claim> GenerateClaims(User user)
        {
            var jwtId = Guid.NewGuid().ToString();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, jwtId), // add the jti claim
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            return claims;
        }

        public static string GenerateRefreshTokenString()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }
        public static RefreshToken GenerateRefreshToken(JwtSettings jwtSettings)
        {
            // Generate the plain refresh token
            var refreshTokenResult = new RefreshToken
            {
                Token = GenerateRefreshTokenString(),
                ExpireDate = DateTime.UtcNow.AddDays(jwtSettings.RefreshTokenExpireDate),
            };

            return refreshTokenResult;
        }

        // Hash a token using SHA-256
        public static string HashToken(string token)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(token);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        public static (JwtSecurityToken, string) GenerateJWTToken(User user, JwtSettings _jwtSettings)
        {
            var claims = GenerateClaims(user);
            var jwtToken = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpireDate),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }
    }
}
