using Core.Featurs.Categories.Commands.Requests;
using Core.Featurs.UnitTypes.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.UnitTypes.Commands.validator;

// Generic base validator
public class UnitTypeBaseValidator<T> : AbstractValidator<T> where T : UnitTypeBaseCommand
{
    public UnitTypeBaseValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.NotNull])
            .Length(2, 30);
    }
}