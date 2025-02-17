using Core.Featurs.Categories.Commands.Requests;
using Core.Featurs.Categories.Commands.Validation;
using Core.Featurs.SaleTypes.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.ServiceImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.SaleTypes.Commands.Validators
{
    public class SaleTypeBaseValidator<T> : AbstractValidator<T> where T : SaleTypeBaseCommand
    {
        public SaleTypeBaseValidator(IStringLocalizer<SharedResources> stringLocalizer)
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
