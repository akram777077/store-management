using Data.Entities.Identity;
using Data.Healper;
using Data.Results;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.Healpers;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceImplementaions
{
    public class AuthenticationService : tokenValidationResponseHandler ,IAuthenticationService 
    {

        private readonly JwtSettings _jwtSettings;
        private readonly IUserRefreshTokenRepository _userRefreshTokensRepository;
        public AuthenticationService(JwtSettings jwtSettings, IUserRefreshTokenRepository userRefreshTokensRepository)
        {
            _jwtSettings = jwtSettings;
            _userRefreshTokensRepository = userRefreshTokensRepository;
        }

        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            var (jwtToken,accessTokenString) = Hashing_and_generating.GenerateJWTToken(user, _jwtSettings);

            var refreshToken = Hashing_and_generating.GenerateRefreshToken(_jwtSettings);//get the refresh token

            var userRefreshTokenRecord = new UserRefreshToken //to save the refresh token in the database
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                JwtId = jwtToken.Id,
                RefreshTokenHashed = Hashing_and_generating.HashToken(refreshToken.Token),
                AddedTime = DateTime.UtcNow,
                ExpiryDate = refreshToken.ExpireDate,
                IsRevoked = false,
                IsUsed = true
            };
            await _userRefreshTokensRepository.AddAsync(userRefreshTokenRecord);

            var result = new JwtAuthResult
            {
                AccessToken = accessTokenString,
                RefreshToken = refreshToken
            };

            return result;
        }

        public JwtSecurityToken ReadJwtToken(string accessToken)
        {
            if(string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }
            var handler = new JwtSecurityTokenHandler();
            var response = handler.ReadJwtToken(accessToken);
            return response;
        }

        public async Task<TokenValidationResponse> ValidateDetails(JwtSecurityToken jwtToken, string accessToken, string refreshToken)
        {
            if (jwtToken == null || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return AlgorithmIsWrong();
            }
            if (jwtToken.ValidTo > DateTime.UtcNow)
            {
                return IsActive();
            }

            //Get User
            var hashedToken = Hashing_and_generating.HashToken(refreshToken);
            var userId = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var jwtIdClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
            if (jwtIdClaim == null)
            {
                return JwtIdNotFound();
            }
            var userRefreshToken = await _userRefreshTokensRepository.GetListAsync()
                                             .FirstOrDefaultAsync(x => x.JwtId == jwtIdClaim &&
                                                                     x.RefreshTokenHashed == hashedToken &&
                                                                     x.UserId == userId);
            if (userRefreshToken == null)
            {
                return RefreshTokenIsNotFound();
            }

            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsUsed = false;
                await _userRefreshTokensRepository.UpdateAsync(userRefreshToken);
                return RefreshTokenIsExpired();
            }
            var expirydate = userRefreshToken.ExpiryDate;
            return Success(userId, userRefreshToken.ExpiryDate);
        }

        public string ValidateToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtSettings.ValidateIssuer,
                ValidIssuers = new[] { _jwtSettings.Issuer },
                ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),
                ValidAudience = _jwtSettings.Audience,
                ValidateAudience = _jwtSettings.ValidateAudience,
                ValidateLifetime = _jwtSettings.ValidateLifeTime,
            };

            try
            {
                var validator = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);
                if (validator is null)
                {
                    return "InvalidToken";
                }
                return "IsActive";
            }
            catch (Exception ex)
            {

                return $"Error: {ex.Message}";
            }
        }

        public JwtAuthResult GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? ExpiryDate, string refreshToken)
        {
            var (response, newToken) = Hashing_and_generating.GenerateJWTToken(user, _jwtSettings); ;
            //Generater refresh token
            var refreshTokenResult = new RefreshToken
            {
                UserId = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)!.Value,
                ExpireDate = ExpiryDate??DateTime.UtcNow.AddDays(1),
                Token = refreshToken
            };

            var result = new JwtAuthResult
            {
                AccessToken = newToken,
                RefreshToken = refreshTokenResult
            };
            return result;

        }
    }
}
