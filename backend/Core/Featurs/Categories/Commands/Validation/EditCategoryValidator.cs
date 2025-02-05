using Core.Featurs.Categories.Commands.Requests;
using Core.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Categories.Commands.Validation
{
    public class EditCategoryValidator : AbstractValidator<EditCategoryCommande>
    {
        #region Fields
        private readonly ICategoryService _categoryService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructor
        public EditCategoryValidator(ICategoryService categoryService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _categoryService = categoryService;
            _stringLocalizer = stringLocalizer;
            ApplayValidationRules();
            ApplayCostumeValidationRules();
        }
        #endregion

        #region Actions
        public void ApplayValidationRules()
        {
            RuleFor(s => s.Id).NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .GreaterThan(0).WithMessage(_stringLocalizer[SharedResourcesKeys.NotValid]);
            RuleFor(s => s.Name).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .Length(2, 30);

            RuleFor(s => s.Description).MaximumLength(500);

        }
        public void ApplayCostumeValidationRules()
        {
            RuleFor(s => s.Name).MustAsync(async (module, key, cancellationToken) => !await _categoryService.IsCategoryNameExists(module.Name, module.Id))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.IsAlreadyExits]);

        }
        #endregion
    }
}