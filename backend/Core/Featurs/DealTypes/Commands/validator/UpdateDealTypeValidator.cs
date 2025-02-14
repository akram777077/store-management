using System;
using Core.Featurs.DealTypes.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.DealTypes.Commands.validator;

public class UpdateDealTypeValidator : AbstractValidator<UpdateDealTypeCommand>
{
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IDealTypeService _dealTypeService;

    public UpdateDealTypeValidator(IStringLocalizer<SharedResources> localizer,IDealTypeService dealTypeService)
    {
        _stringLocalizer = localizer;
        _dealTypeService = dealTypeService;
        ApplayValidationRules();
        ApplayCostumeValidationRules();
    }
    public void ApplayValidationRules()
    {
        RuleFor(s => s.Id).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
            .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);
        Include(new DealTypeBaseValidator<UpdateDealTypeCommand>(_stringLocalizer));
    }
    public void ApplayCostumeValidationRules()
    {
        RuleFor(s => s.Name).MustAsync(async (module, key, cancellationToken) => !await _dealTypeService.IsDealTypeNameExistsAsync(module.Name, module.Id))
            .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

    }

}
