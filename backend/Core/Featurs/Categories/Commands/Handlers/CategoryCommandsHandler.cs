using AutoMapper;
using Core.Bases;
using Core.Featurs.Categories.Commands.Requests;
using Core.Localization;
using Data.Entities;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Categories.Commands.Handlers
{
    public class CategoryCommandsHandler : ResponseHandler,
        IRequestHandler<CreateCategoryCommand, Response<string>>,
        IRequestHandler<EditCategoryCommande, Response<string>>
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructor
        public CategoryCommandsHandler(IStringLocalizer<SharedResources> stringLocalizer, ICategoryService categoryService, IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        #endregion

        #region Function Handling
        public async Task<Response<string>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category =  _mapper.Map<Category>(request);
            var response = await _categoryService.AddAsync(category);
            
            return Created("");
        }

        public async Task<Response<string>> Handle(EditCategoryCommande request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAsync(request.Id);
            if(category == null)
                return NotFound<string>();

            _mapper.Map(request, category);

            await _categoryService.UpdateAsync(category);
            return Success("");

        }
        #endregion
    }
}
