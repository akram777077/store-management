using Core.Featurs.Inventories.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.Inventories.Commands.Validation
{
    public class UpdateInventoryValidator : AbstractValidator<UpdateInventoryCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IInventoryService _inventoryService;

        public UpdateInventoryValidator(IStringLocalizer<SharedResources> stringLocalizer, IInventoryService inventoryService)
        {
            _stringLocalizer = stringLocalizer;
            _inventoryService = inventoryService;
            ApplyValidationRules();
            ApplyCustomeValidationRules();
        }


        public void ApplyValidationRules()
        {
            RuleFor(i => i.Id).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            Include(new InventoryBaseValidator<UpdateInventoryCommand>(_stringLocalizer));
        }

        public void ApplyCustomeValidationRules()
        {
            RuleFor(i => i.Location)
                .MustAsync(async (module, key, cancellationToken) => !await _inventoryService.
                IsInventoryLocationIsExists(module.Location, module.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);
        }

    }
}
