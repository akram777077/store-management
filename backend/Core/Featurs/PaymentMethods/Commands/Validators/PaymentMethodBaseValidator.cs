using Core.Featurs.PaymentMethods.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.ServiceImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.PaymentMethods.Commands.Validators
{
    public class PaymentMethodBaseValidator<T> : AbstractValidator<T> where T : PaymentMethodBaseCommand
    {
        public PaymentMethodBaseValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.NotNull])
                .Length(2, 30);
        }
    }
}
