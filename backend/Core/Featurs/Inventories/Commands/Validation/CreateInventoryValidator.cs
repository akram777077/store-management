using Core.Featurs.Inventories.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Featurs.Inventories.Commands.Validation
{
    public class CreateInventoryValidator : AbstractValidator<CreateInventoryCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizers;
        private readonly IInventoryService _inventoryService;

        public CreateInventoryValidator(IStringLocalizer<SharedResources> stringLocalizers, IInventoryService inventoryService)
        {
            _stringLocalizers = stringLocalizers;
            _inventoryService = inventoryService;
            ApplyValidatorRules();
            ApplyCostumeValidationRules();
        }


        public void ApplyValidatorRules()
        {
            Include(new InventoryBaseValidator<CreateInventoryCommand>(_stringLocalizers));
        }


        public void ApplyCostumeValidationRules()
        {
            RuleFor(i => i.Location)
                .MustAsync(async (module, key, cancellationToken) => !await 
                _inventoryService.IsInventoryLocationIsExists(module.Location))
                .WithMessage(_stringLocalizers[SharedResourcesKeys.IsAlreadyExits]);
        }
    }
}
