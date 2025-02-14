using AutoMapper;
using Core.Bases;
using Core.Featurs.DealTypes.Query.Request;
using Core.Featurs.DealTypes.Query.Response;
using Core.Localization;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;

namespace Core.Featurs.DealTypes.Query.Handler
{
    public class DealTypeQueryHandler : ResponseHandler, 
        IRequestHandler<GetDealTypeByIdRequest, Response<GetDealTypeResponse>>,
        IRequestHandler<GetDealTypeByNameRequest, Response<GetDealTypeResponse>>,
        IRequestHandler<GetDealTypesListRequest, Response<IEnumerable<GetDealTypeResponse>>>
    {
        private readonly IDealTypeService _dealTypeService;
        private readonly IStringLocalizer<SharedResourcesKeys> _stringLocalizer;
        private readonly IMapper _mapper;

        public DealTypeQueryHandler(IDealTypeService dealTypeService, IStringLocalizer<SharedResourcesKeys> stringLocalizer, IMapper mapper)
          :base(stringLocalizer)
        {
            _dealTypeService = dealTypeService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }

        public async Task<Response<GetDealTypeResponse>> Handle(GetDealTypeByIdRequest request, CancellationToken cancellationToken)
        {
            if(request.Id <= 0)
                return BadRequest<GetDealTypeResponse>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            var entity = await _dealTypeService.GetByIdAsync(request.Id);
            if (entity is null)
                return NotFound<GetDealTypeResponse>();
            var entityMap = _mapper.Map<GetDealTypeResponse>(entity);
            return Success(entityMap);
        }

        public async Task<Response<GetDealTypeResponse>> Handle(GetDealTypeByNameRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest<GetDealTypeResponse>(nameof(request.Name) + ": " + _stringLocalizer[SharedResourcesKeys.NotEmpty]);

            var entity = await _dealTypeService.GetDealTypeByNameAsync(request.Name);
            if (entity is null)
                return NotFound<GetDealTypeResponse>();
            var entityMap = _mapper.Map<GetDealTypeResponse>(entity);
            return Success(entityMap);
        }

        public async Task<Response<IEnumerable<GetDealTypeResponse>>> Handle(GetDealTypesListRequest request, CancellationToken cancellationToken)
        {
            var dealTypes = await _dealTypeService.GetListAsync();
            var dealTypesList = _mapper.Map<IEnumerable<GetDealTypeResponse>>(dealTypes);
            return Success(dealTypesList);
        }
    }
}
