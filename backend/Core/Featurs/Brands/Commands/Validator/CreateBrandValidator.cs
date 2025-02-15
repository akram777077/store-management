using Core.Featurs.Brands.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.Brands.Commands.Validator
{
    public class CreateBrandValidator : AbstractValidator<CreateBrandCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IBrandService _brandService;

        public CreateBrandValidator(IStringLocalizer<SharedResources> stringLocalizer, IBrandService brandService)
        {
            _stringLocalizer = stringLocalizer;
            _brandService = brandService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            Include(new BrandBaseValidator<CreateBrandCommand>(_stringLocalizer));
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(s => s.Name)
                .MustAsync(async (module, key, cancellationToken) => !await _brandService.IsBrandNameExistsAsync(module.Name))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);
        }
    }

}
