using Core.Featurs.PaymentMethods.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.PaymentMethods.Commands.Validators
{
    public class UpdatePaymentMethodValidator : AbstractValidator<UpdatePaymentMethodCommand> 
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IPaymentMethodService _paymentMethodService;

        public UpdatePaymentMethodValidator(IStringLocalizer<SharedResources> localizer, IPaymentMethodService paymentMethodService)
        {
            _stringLocalizer = localizer;
            _paymentMethodService = paymentMethodService;
            ApplyValidationRules();
            ApplyCostumeValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            Include(new PaymentMethodBaseValidator<UpdatePaymentMethodCommand>(_stringLocalizer));
        }

        public void ApplyCostumeValidationRules()
        {
            RuleFor(s => s.Name)
                .MustAsync(async (module, key, cancellationToken) => !await _paymentMethodService.IsPaymentMethodNameExistsAsync(module.Name, module.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);
        }
    }
}
