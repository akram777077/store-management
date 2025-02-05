    using Core.Featurs.UnitType.Commands.Requests;
    using Core.Localization;
    using FluentValidation;
    using Microsoft.Extensions.Localization;
    using ServiceLayer.Interfaces;

    namespace Core.Featurs.UnitType.Commands.validator;

    public class NameOfUnitTypeValidator<T> : AbstractValidator<T>
        where T : UnitTypeNameOnlyCommand
    {
        private readonly IUnitTypeService _service;
        private readonly IStringLocalizer<SharedResources> _localizer;

        public NameOfUnitTypeValidator(IUnitTypeService service,IStringLocalizer<SharedResources> localizer)
        {
            _service = service;
            _localizer = localizer;
            ApplyValidationRules();
        }

        private void ApplyValidationRules()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull])
                .Length(1, 30);
        }
    }