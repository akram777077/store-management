﻿using Core.Bases;
using Core.Featurs.Authorization.Commands.Models;
using Core.Localization;
using Data.Entities.Identity;
using ServiceLayer.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Authorization.Commands.Handler
{
    public class RoleCommandsHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, Response<string>>,
        IRequestHandler<EditRoleCommand, Response<string>>,
        IRequestHandler<DeleteRoleCommand, Response<string>>,
        IRequestHandler<UpdateUserRoleCommand, Response<string>>

    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        #endregion

        #region Constructor
        public RoleCommandsHandler(RoleManager<Role> roleManager
            , IStringLocalizer<SharedResources> stringLocalizer,
            IAuthorizationService authorizationService) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
        }
        #endregion


        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.AddRole(request.RoleName);
            if (result == "Succeeded") return Success("");
            else if (result == "DuplicateRoleName") return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.RoleAlreadyExists]);
            else return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.EditRole(request);
            if (result == "NotFound") return NotFound<string>();
            else if (result == "Succeeded") return Success<string>(_stringLocalizer[SharedResourcesKeys.Updated]);
            else if (result == "DuplicateRoleName") return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.RoleAlreadyExists]);
            else return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.DeleteRole(request.RoleName);

            if (result == "NotFound") return BadRequest<string>();
            if(result == "Used") return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.RoleIsInUse]);
            if (result == "Succeeded") return Success<string>(_stringLocalizer[SharedResourcesKeys.Deleted]);
            else return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationService.ManageUserRole(request);
            switch (result)
            {
                case "NotFound": return NotFound<string>(_stringLocalizer[SharedResourcesKeys.UserNotFound]);
                case "FailedToRemoveOldRoles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToRemoveOldRoles]);
                case "FailedToAddNewRoles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.FailedToAddNewRoles]);
                case "Success": return Success<string>(_stringLocalizer[SharedResourcesKeys.Updated]);
                case "FailedToUpdateUserRoles": return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.UpdateFailed]);
                default:
                    return Success<string>(result);
            }
        }
    }
}
