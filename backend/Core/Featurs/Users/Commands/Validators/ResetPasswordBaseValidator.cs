using Core.Featurs.Users.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Core.Featurs.Users.Commands.Validators
{
    public class ResetPasswordBaseValidator<T> : AbstractValidator<T> where T : ResetPasswordBaseCommand
    {
        public ResetPasswordBaseValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.Required]);

            RuleFor(x => x.NewPassword)
                 .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.Required]);
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.NewPassword).WithMessage(stringLocalizer[SharedResourcesKeys.PasswordNotEqualConfirmPass]);

        }
    }
}
