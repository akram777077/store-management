using AutoMapper;
using Core.Bases;
using Core.Featurs.Brands.Query.Request;
using Core.Featurs.Brands.Query.Response;
using Core.Localization;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.Brands.Query.Handler
{
    public class BrandQueryHandler : ResponseHandler,
        IRequestHandler<GetBrandByIdRequest, Response<GetBrandResponse>>,
        IRequestHandler<GetBrandByNameRequest, Response<GetBrandResponse>>,
        IRequestHandler<GetBrandListRequest, Response<IEnumerable<GetBrandResponse>>>
    {
        private readonly IBrandService _brandService;
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IMapper _mapper;

        public BrandQueryHandler(IBrandService brandService, IStringLocalizer<SharedResources> localizer, IMapper mapper)
              : base(localizer)
        {
            _brandService = brandService;
            _stringLocalizer = localizer;
            _mapper = mapper;
        }

        public async Task<Response<GetBrandResponse>> Handle(GetBrandByIdRequest request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                return BadRequest<GetBrandResponse>(_stringLocalizer[SharedResourcesKeys.BadRequest]); 

            var entity = await _brandService.GetByIdAsync(request.Id);
            if (entity is null)
                return NotFound<GetBrandResponse>();
            var entityMap = _mapper.Map<GetBrandResponse>(entity);
            return Success(entityMap);
        }

        public async Task<Response<GetBrandResponse>> Handle(GetBrandByNameRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest<GetBrandResponse>(nameof(request.Name) + ": " + _stringLocalizer[SharedResourcesKeys.NotEmpty]);

            var entity = await _brandService.GetBrandByNameAsync(request.Name);
            if (entity is null)
                return NotFound<GetBrandResponse>();
            var entityMap = _mapper.Map<GetBrandResponse>(entity);
            return Success(entityMap);
        }
            
        public async Task<Response<IEnumerable<GetBrandResponse>>> Handle(GetBrandListRequest request, CancellationToken cancellationToken)
        {
            var brands = await _brandService.GetListAsync();
            var brandsList = _mapper.Map<IEnumerable<GetBrandResponse>>(brands);
            return Success(brandsList);
        }
    }
}
