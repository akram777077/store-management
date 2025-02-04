using Core.Featurs.UnitType.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.UnitType.Commands.validator;

public class CreateUnitTypeValidator : AbstractValidator<CreateUnitTypeCommand>
{
    private readonly IUnitTypeService _service;
    private readonly IStringLocalizer<SharedResources> _localizer;

    public CreateUnitTypeValidator(IUnitTypeService service,IStringLocalizer<SharedResources> localizer)
    {
        _service = service;
        _localizer = localizer;
        ApplyValidationRules();
        ApplyCustomValidation();
    }

    private void ApplyValidationRules()
    {
        RuleFor(u => u.Name)
            .NotEmpty()
            .WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
            .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull])
            .Length(1, 30);
    }
    private void ApplyCustomValidation()
    {
        RuleFor(u => u.Name).MustAsync(async (name, cancellation) =>
        {
            var unitType = await _service.GetUnitTypesByNameAsync(name);
            return unitType is null;
        }).WithMessage(_localizer[SharedResourcesKeys.IsAlreadyExits]);
    }
}