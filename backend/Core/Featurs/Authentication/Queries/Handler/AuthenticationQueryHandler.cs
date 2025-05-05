using Core.Bases;
using Core.Featurs.Authentication.Queries.Requests;
using Core.Localization;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Authentication.Queries.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler,
        IRequestHandler<CheckTokenExpiryQuery, Response<string>>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthenticationService _authenticationService;
        #endregion
        #region Constructor
        public AuthenticationQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IAuthenticationService authenticationService) : base(stringLocalizer)
        {
            this._stringLocalizer = stringLocalizer;
            _authenticationService = authenticationService;
        }
        #endregion

        #region Handler
        public async Task<Response<string>> Handle(CheckTokenExpiryQuery request, CancellationToken cancellationToken)
        {
            var result = _authenticationService.ValidateToken(request.AccessToken);
            return result == "IsActive" ? Success(result) : Unauthorized<string>(_stringLocalizer[SharedResourcesKeys.TokenIsExpired]);
        }
        #endregion
    }
}
