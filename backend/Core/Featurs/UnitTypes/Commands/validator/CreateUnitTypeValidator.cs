using Core.Featurs.UnitTypes.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.UnitTypes.Commands.validator
{
    public class CreateUnitTypeValidator : AbstractValidator<CreateUnitTypeCommand>
    {
        #region Fields
        private readonly IUnitTypeService _unitTypeService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructor
        public CreateUnitTypeValidator(IStringLocalizer<SharedResources> stringLocalizer, IUnitTypeService unitTypeService)
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
            Include(new UnitTypeBaseValidator<CreateUnitTypeCommand>(_stringLocalizer));

        }
        public void ApplayCostumeValidationRules()
        {
            RuleFor(s => s.Name).MustAsync(async (module, key, cancellationToken) => !await _unitTypeService.IsUnitTypeNameExists(module.Name))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

        }
        #endregion
    }
}
