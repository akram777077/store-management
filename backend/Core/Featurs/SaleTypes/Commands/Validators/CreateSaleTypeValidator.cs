using Core.Featurs.SaleTypes.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.SaleTypes.Commands.Validators
{
    public class CreateSaleTypeValidator : AbstractValidator<CreateSaleTypeCommand>
    {
        #region Fields
        private readonly ISaleTypeService _saleTypeService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructor
        public CreateSaleTypeValidator(ISaleTypeService saleTypeService, IStringLocalizer<SharedResources> stringLocalizer)
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
            Include(new SaleTypeBaseValidator<CreateSaleTypeCommand>(_stringLocalizer));

        }
        public void ApplyCostumeValidationRules()
        {
            RuleFor(s => s.Name)
                .MustAsync(async (module, key, cancellationToken) => !await _saleTypeService.IsSaleTypeNameExists(module.Name))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

        }
        #endregion
    }
}
