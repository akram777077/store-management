using Core.Featurs.DealTypes.Commands.Requests;
using Core.Featurs.Users.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Users.Commands.Validators
{
    public class UpdateUserBaseValidator<T> : AbstractValidator<T> where T : UpdateUserBaseCommand
    {
        public UpdateUserBaseValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(stringLocalizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.Required]);
        }
    }
}
