using Core.Featurs.SaleTypes.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.SaleTypes.Commands.Validators
{
    public class UpdateSaleTypeValidator : AbstractValidator<UpdateSaleTypeCommand>
    {
        #region Fields
        private readonly ISaleTypeService _saleTypeService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructor
        public UpdateSaleTypeValidator(ISaleTypeService saleTypeService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _saleTypeService = saleTypeService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCostumeValidationRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            Include(new SaleTypeBaseValidator<UpdateSaleTypeCommand>(_stringLocalizer));

        }
        public void ApplyCostumeValidationRules()
        {
            RuleFor(s => s.Name)
                .MustAsync(async (module, key, cancellationToken) => !await _saleTypeService.IsSaleTypeNameExists(module.Name, module.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

        }
        #endregion
    }
}
