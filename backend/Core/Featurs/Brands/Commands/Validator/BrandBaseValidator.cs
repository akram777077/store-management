using Core.Featurs.Brands.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace Core.Featurs.Brands.Commands.Validator
{
    public class BrandBaseValidator<T> : AbstractValidator<T> where T : BrandBaseCommand
    {
        public BrandBaseValidator(IStringLocalizer<SharedResources> stringLocalizer)
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage(stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(stringLocalizer[SharedResourcesKeys.NotNull])
                .Length(2, 30);
        }
    }
}
