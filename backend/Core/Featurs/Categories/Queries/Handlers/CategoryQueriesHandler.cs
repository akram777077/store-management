using AutoMapper;
using Core.Bases;
using Core.Featurs.Categories.Queries.Responses;
using Core.Featurs.Categories.Queries.Resquests;
using Core.Localization;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Categories.Queries.Handlers
{
    public class CategoryQueriesHandler : ResponseHandler, IRequestHandler<GetCategoriesListQuery, Response<IEnumerable<GetCategoriesListResponse>>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryQueriesHandler(IStringLocalizer<SharedResources> stringLocalizer, ICategoryService categoryService, IMapper mapper) : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetCategoriesListResponse>>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetListAsync();
            var categoriesmapper = _mapper.Map<IEnumerable<GetCategoriesListResponse>>(categories);
            var result = Success(categoriesmapper);
            result.Meta = new
            {
                Count = categoriesmapper.Count(),
            };// you can add any thing you want
            return result;

        }
    }
}
