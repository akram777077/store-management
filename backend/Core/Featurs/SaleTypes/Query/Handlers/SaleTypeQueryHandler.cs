using AutoMapper;
using Core.Bases;
using Core.Featurs.SaleTypes.Query.Requests;
using Core.Featurs.SaleTypes.Query.Response;
using Core.Localization;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.SaleTypes.Query.Handlers
{
    public class SaleTypeQueryHandler : ResponseHandler,
    IRequestHandler<GetSaleTypesListQuery, Response<IEnumerable<GetSaleTypesResponse>>>,
    IRequestHandler<GetSaleTypeByIdQuery, Response<GetSaleTypesResponse>>,
    IRequestHandler<GetSaleTypeByNameQuery, Response<GetSaleTypesResponse>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly ISaleTypeService _saleTypeService;
        private readonly IMapper _mapper;

        public SaleTypeQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, ISaleTypeService saleTypeService, IMapper mapper)
            : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _saleTypeService = saleTypeService;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetSaleTypesResponse>>> Handle(GetSaleTypesListQuery request, CancellationToken cancellationToken)
        {
            var saleType = await _saleTypeService.GetListAsync();
            var saleTypeMapper = _mapper.Map<IEnumerable<GetSaleTypesResponse>>(saleType);
            var result = Success(saleTypeMapper);

            result.Meta = new
            {
                Count = saleTypeMapper.Count(),
            };// you can add any thing you want
            
            return result;
        }

        public async Task<Response<GetSaleTypesResponse>> Handle(GetSaleTypeByIdQuery request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                return BadRequest<GetSaleTypesResponse>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            var saleType = await _saleTypeService.GetByIdAsync(request.Id);
            if (saleType == null)
            {
                return NotFound<GetSaleTypesResponse>();
            }

            var saleTypesMapper = _mapper.Map<GetSaleTypesResponse>(saleType);
            return Success(saleTypesMapper);
        }

        public async Task<Response<GetSaleTypesResponse>> Handle(GetSaleTypeByNameQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
                return BadRequest<GetSaleTypesResponse>(nameof(request.Name) + ": " + _stringLocalizer[SharedResourcesKeys.NotEmpty]);

            var saleType = await _saleTypeService.GetSaleTypeByName(request.Name);
            if (saleType == null)
                return NotFound<GetSaleTypesResponse>();

            var saleTypesMapper = _mapper.Map<GetSaleTypesResponse>(saleType);
            return Success(saleTypesMapper);
        }
    }

}
