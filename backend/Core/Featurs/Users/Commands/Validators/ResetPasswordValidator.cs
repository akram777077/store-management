using Core.Featurs.Users.Commands.Requests;
using Core.Localization;
using Data.Entities.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Commands.Validators
{
    public class ResetPasswordValidator : AbstractValidator<ResetPasswordCommand>
    {
        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly UserManager<User> _userManager;

        #endregion

        #region Constructors
        public ResetPasswordValidator(IStringLocalizer<SharedResources> localizer, UserManager<User> userManager)
        {
            _stringLocalizer = localizer;
            _userManager = userManager;
            ApplyValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
            Include(new ResetPasswordBaseValidator<ResetPasswordCommand>(_stringLocalizer));

        }

        #endregion
    }
}
