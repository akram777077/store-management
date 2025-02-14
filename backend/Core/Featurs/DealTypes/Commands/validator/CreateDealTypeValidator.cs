using System;
using Core.Featurs.DealTypes.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using ServiceLayer.ServiceImplementations;

namespace Core.Featurs.DealTypes.Commands.validator;

public class CreateDealTypeValidator : AbstractValidator<CreateDealTypeCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IDealTypeService _dealTypeService;

    public CreateDealTypeValidator(IStringLocalizer<SharedResources> localizer,IDealTypeService dealTypeService)
    {
        _stringLocalizer = localizer;
        _dealTypeService = dealTypeService;
        ApplayValidationRules();
        ApplayCostumeValidationRules();
    }
    public void ApplayValidationRules()
    {
        Include(new DealTypeBaseValidator<CreateDealTypeCommand>(_stringLocalizer));
    }
    public void ApplayCostumeValidationRules()
    {
        RuleFor(s => s.Name).MustAsync(async (module, key, cancellationToken) => !await _dealTypeService.IsDealTypeExistsAsync(module.Name))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

    }
}
