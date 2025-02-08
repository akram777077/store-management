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
        IRequestHandler<UpdateCategoryCommand, Response<string>>,
        IRequestHandler<DeleteCategoryCommand, Response<string>>
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

        public async Task<Response<string>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetByIdAsync(request.Id);
            if(category == null)
                return NotFound<string>();

            _mapper.Map(request, category);

            await _categoryService.UpdateAsync(category);
            return Success("");

        }

        public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            // quick validation for the Id
            if (request.Id < 1)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            //check if Id exists
            var category = await _categoryService.GetByIdAsync(request.Id);

            //return not found if not exist
            if (category == null)
                return NotFound<string>();

            //cal the edit service
            var result = await _categoryService.DeleteAsync(category);

            //return response
            if (result == "Deleted") return Deleted<string>("");
            else return InternalServerError<string>();
        }
        #endregion
    }
}
