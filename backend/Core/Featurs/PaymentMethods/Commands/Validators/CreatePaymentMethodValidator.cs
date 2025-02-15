using Core.Featurs.PaymentMethods.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.PaymentMethods.Commands.Validators
{
    public class CreatePaymentMethodValidator : AbstractValidator<CreatePaymentMethodCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IPaymentMethodService _paymentMethodService;

        public CreatePaymentMethodValidator(IStringLocalizer<SharedResources> localizer, IPaymentMethodService paymentMethodService)
        {
            _stringLocalizer = localizer;
            _paymentMethodService = paymentMethodService;
            ApplyValidationRules();
            ApplyCostumeValidationRules();
        }
        public void ApplyValidationRules()
        {
            Include(new PaymentMethodBaseValidator<CreatePaymentMethodCommand>(_stringLocalizer));
        }

        public void ApplyCostumeValidationRules()
        {
            RuleFor(s => s.Name)
                .MustAsync(async (module, key, cancellationToken) => !await _paymentMethodService.IsPaymentMethodNameExistsAsync(module.Name))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);
        }
    }
}
