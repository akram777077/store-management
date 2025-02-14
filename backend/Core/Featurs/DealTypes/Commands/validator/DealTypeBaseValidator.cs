using System;
using Core.Featurs.DealTypes.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Core.Featurs.DealTypes.Commands.validator;

public class DealTypeBaseValidator<T> : AbstractValidator<T> where T : DealTypeBaseCommand
{
    public DealTypeBaseValidator(IStringLocalizer<SharedResources> stringLocalizer)
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.NotNull])
            .Length(2, 30);
    }
}
