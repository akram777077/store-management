﻿using Core.Featurs.Authorization.Commands.Models;
using Core.Localization;
using ServiceLayer.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Authorization.Commands.Validation
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IAuthorizationService _authorizationService;
        #endregion
        #region Constructor
        public DeleteRoleValidator(IStringLocalizer<SharedResources> stringLocalizer, IAuthorizationService authorizationService)
        {
            _stringLocalizer = stringLocalizer;
            _authorizationService = authorizationService;
            ApplayValidationRules();
            //ApplayCostumeValidationRules();
        }
        #endregion

        #region Action
        public void ApplayValidationRules()
        {
            RuleFor(s => s.RoleName).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
        }

        //public void ApplayCostumeValidationRules()
        //{
        //    RuleFor(s => s.RoleName).MustAsync(async (key, cancellationToken) => await _authorizationService.IsRoleExists(key))
        //        .WithMessage(_stringLocalizer[SharedResourcesKeys.RoleDoseNotExist]);
        //}

        #endregion
    }

}
