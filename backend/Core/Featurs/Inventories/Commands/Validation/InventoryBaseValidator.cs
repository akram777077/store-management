using Core.Featurs.Inventories.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Inventories.Commands.Validation
{
    public class InventoryBaseValidator<T> : AbstractValidator<T> where T : InventoryBaseCommand
    {

        public InventoryBaseValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            RuleFor(i => i.Location)
                .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.NotNull])
                .Length(5, 30);

            RuleFor(i => i.Quantity)
                .GreaterThan(0).WithMessage(stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            RuleFor(i => i.LastUpdate)
                .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.NotNull]);
        }
    }
}
