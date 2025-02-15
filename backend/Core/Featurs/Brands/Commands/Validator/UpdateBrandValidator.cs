using Core.Featurs.Brands.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.Brands.Commands.Validator
{
    public class UpdateBrandValidator : AbstractValidator<UpdateBrandCommand>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IBrandService _brandService;

        public UpdateBrandValidator(IStringLocalizer<SharedResources> stringLocalizer, IBrandService brandService)
        {
            _stringLocalizer = stringLocalizer;
            _brandService = brandService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(s => s.Id)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            Include(new BrandBaseValidator<UpdateBrandCommand>(_stringLocalizer));
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(s => s.Name)
                .MustAsync(async (module, key, cancellationToken) => !await _brandService.IsBrandNameExistsAsync(module.Name, module.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);
        }
    }
}
