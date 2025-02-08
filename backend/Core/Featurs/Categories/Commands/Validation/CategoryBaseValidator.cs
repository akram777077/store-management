using Core.Featurs.Categories.Commands.Requests;
using Core.Localization;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Categories.Commands.Validation
{
    // Generic base validator
    public class CategoryBaseValidator<T> : AbstractValidator<T> where T : CategoryBaseCommand
    {
        public CategoryBaseValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.NotNull])
                .Length(2, 30);

            RuleFor(s => s.Description)
                .MaximumLength(500);
        }
    }
}
