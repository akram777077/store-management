using Core.Featurs.DealTypes.Commands.Requests;
using Core.Featurs.DealTypes.Commands.validator;
using Core.Featurs.Users.Commands.Requests;
using Core.Localization;
using Data.Entities.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Commands.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructors
        public CreateUserValidator(IStringLocalizer<SharedResources> localizer, UserManager<User> userManager)
        {
            _stringLocalizer = localizer;
            _userManager = userManager;
            ApplayValidationRules();
            ApplayCostumeValidationRules();
        }
        #endregion

        #region Handle Functions
        public void ApplayValidationRules()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage(_stringLocalizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);


        }
        public void ApplayCostumeValidationRules()
        {
            RuleFor(s => s.UserName).MustAsync(async (key, cancellationToken) => await _userManager.FindByNameAsync(key) == null)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

            RuleFor(s => s.Email).MustAsync(async (key, cancellationToken) => await _userManager.FindByEmailAsync(key) == null)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

            RuleFor(s => s.PhoneNumber).MustAsync(async (key, cancellationToken) => !await _userManager.Users.AnyAsync(x => x.PhoneNumber == key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

        }
        #endregion
    }
}
