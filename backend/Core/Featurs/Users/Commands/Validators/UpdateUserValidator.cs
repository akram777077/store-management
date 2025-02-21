using Core.Featurs.DealTypes.Commands.Requests;
using Core.Featurs.DealTypes.Commands.validator;
using Core.Featurs.Users.Commands.Requests;
using Core.Localization;
using Data.Entities.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Commands.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;

        #endregion

        #region Constructors
        public UpdateUserValidator(IStringLocalizer<SharedResources> localizer, UserManager<User> userManager)
        {
            _stringLocalizer = localizer;
            _userManager = userManager;
            ApplyValidationsRules();
            ApplayCostumeValidationRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(s => s.Id).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull]);
            Include(new UpdateUserBaseValidator<UpdateUserCommand>(_stringLocalizer));
        }
        public void ApplayCostumeValidationRules()
        {

            RuleFor(s => s.UserName).MustAsync(async (module, key, cancellationToken) => await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == module.UserName && x.Id != module.Id) == null)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

            RuleFor(s => s.Email).MustAsync(async (module, key, cancellationToken) => await _userManager.Users.FirstOrDefaultAsync(x => x.Email == module.Email && x.Id != module.Id) == null)
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

            RuleFor(s => s.PhoneNumber).MustAsync(async (module, key, cancellationToken) => !await _userManager.Users.AnyAsync(x => x.PhoneNumber == module.PhoneNumber && x.Id != module.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

        }

        #endregion
    }
}
