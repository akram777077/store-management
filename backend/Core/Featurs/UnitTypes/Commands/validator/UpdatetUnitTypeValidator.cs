using Core.Featurs.UnitTypes.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.UnitTypes.Commands.validator
{
    public class UpdatetUnitTypeValidator : AbstractValidator<UpdateUnitTypeCommand>
    {
        #region Fields
        private readonly IUnitTypeService _unitTypeService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructor
        public UpdatetUnitTypeValidator(IStringLocalizer<SharedResources> stringLocalizer, IUnitTypeService unitTypeService)
        {
            _stringLocalizer = stringLocalizer;
            _unitTypeService = unitTypeService;
            ApplayValidationRules();
            ApplayCostumeValidationRules();
        }
        #endregion

        #region Actions
        public void ApplayValidationRules()
        {
            RuleFor(s => s.Id).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);
            Include(new UnitTypeBaseValidator<UpdateUnitTypeCommand>(_stringLocalizer));
        }
        public void ApplayCostumeValidationRules()
        {
            RuleFor(s => s.Name).MustAsync(async (module, key, cancellationToken) => !await _unitTypeService.IsUnitTypeNameExists(module.Name, module.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

        }
        #endregion
    }
}
