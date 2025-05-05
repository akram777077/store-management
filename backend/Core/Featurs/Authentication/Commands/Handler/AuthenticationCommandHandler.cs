using Core.Bases;
using Core.Featurs.Authentication.Commands.Request;
using Core.Featurs.Users.Commands.Requests;
using Core.Localization;
using Data.Entities.Identity;
using Data.Healper;
using Data.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Authentication.Commands.Handler
{
    public class AuthenticationCommandHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtAuthResult>>,
        IRequestHandler<RefreshTokenCommand, Response<JwtAuthResult>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        #endregion

        #region Constructor
        public AuthenticationCommandHandler(IStringLocalizer<SharedResources> stringLocalizer, UserManager<User> userManager, SignInManager<User> signInManager, IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }
        #endregion

        #region Actions
        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user is exist or not
            var user = await _userManager.FindByEmailAsync(request.Email);
            //Return The Email Not Found
            if (user == null) return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.EmailDoseNotExist]);
            
            //try To Sign in 
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);
            //if Failed Return Passord is wrong
            if (!signInResult.Succeeded)
            {
                if (await _userManager.IsLockedOutAsync(user))
                {
                    var lockoutEndUtc = user.LockoutEnd ?? DateTimeOffset.UtcNow;
                    var remainingTime = (lockoutEndUtc - DateTimeOffset.UtcNow).TotalMinutes;

                    return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.SignInLocked] + " " +
                        _stringLocalizer[SharedResourcesKeys.TryAgain] + " " +
                        _stringLocalizer[SharedResourcesKeys.After] + $" {Math.Ceiling(remainingTime)} " +
                        _stringLocalizer[SharedResourcesKeys.min]);
                }
                return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.WrongPassword]);
            }
            ////confirm email
            //if (!user.EmailConfirmed)
            //    return BadRequest<JwtAuthResult>(_stringLocalizer[SharedResourcesKeys.EmailNotConfirmed]);

            //Generate Token
            var result = await _authenticationService.GetJWTToken(user);
            //return Token 
            return Success(result);
        }

        public async Task<Response<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            JwtSecurityToken jwtToken = _authenticationService.ReadJwtToken(request.AccessToken);
            var validationResult = await _authenticationService.ValidateDetails(jwtToken, request.AccessToken, request.RefreshToken);
            if (!validationResult.Succeeded)
            {
                return Unauthorized<JwtAuthResult>(_stringLocalizer[validationResult.Message]);
            }
            var userId = validationResult.UserId;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound<JwtAuthResult>();

            var response = _authenticationService.GetRefreshToken(user, jwtToken, validationResult.ExpiryDate, request.RefreshToken);
            return Success(response);
        }

        #endregion
    }
}
