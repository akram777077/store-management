using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Healpers
{
    public class tokenValidationResponseHandler
    {
        
        public TokenValidationResponse AlgorithmIsWrong()
        {
            return new TokenValidationResponse()
            {
                Succeeded = false,
                Message = "AlgorithmIsWrong"
            };
        }
        public TokenValidationResponse IsActive()
        {
            return new TokenValidationResponse()
            {
                Succeeded = false,
                Message = "TheTokenIsActive"
            };
        }
        
        public TokenValidationResponse JwtIdNotFound()
        {
            return new TokenValidationResponse()
            {
                Succeeded = false,
                Message = "JwtIdNotFound"
            };
        }
        public TokenValidationResponse RefreshTokenIsNotFound()
        {
            return new TokenValidationResponse()
            {
                Succeeded = false,
                Message = "RefreshTokenIsNotFound"
            };
        }

        public TokenValidationResponse RefreshTokenIsExpired()
        {
            return new TokenValidationResponse()
            {
                Succeeded = false,
                Message = "RefreshTokenIsExpired"
            };
        }

        public TokenValidationResponse Success(string userId, DateTime expireDate)
        {
            return new TokenValidationResponse()
            {
                Succeeded = true,
                Message = "TokenIsValid",
                UserId = userId,
                ExpiryDate = expireDate
            };
        }

    }
}
