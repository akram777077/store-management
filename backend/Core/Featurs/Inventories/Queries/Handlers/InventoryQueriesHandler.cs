using AutoMapper;
using Core.Bases;
using Core.Featurs.Inventories.Queries.Requests;
using Core.Featurs.Inventories.Queries.Response;
using Core.Localization;
using MediatR;
using Microsoft.Extensions.Localization;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Featurs.Inventories.Queries.Handlers
{
    public class InventoryQueriesHandler : ResponseHandler,
        IRequestHandler<GetInventoriesById, Response<GetInventoriesResponse>>,
        IRequestHandler<GetInventoriesByLocationQuery, Response<GetInventoriesResponse>>, 
        IRequestHandler<GetInventoriesListQuery, Response<IEnumerable<GetInventoriesResponse>>>
    {
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public InventoryQueriesHandler(IStringLocalizer<SharedResources> stringLocalizer, IInventoryService inventoryService, IMapper mapper) 
            : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _inventoryService = inventoryService;
            _mapper = mapper;
        }


        public async Task<Response<GetInventoriesResponse>> Handle(GetInventoriesById request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0) return BadRequest<GetInventoriesResponse>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            var inventory = await _inventoryService.GetByIdAsync(request.Id);

            if (inventory == null) return NotFound<GetInventoriesResponse>();

            var inventoryMapper = _mapper.Map<GetInventoriesResponse>(inventory);

            return Success(inventoryMapper);
        }

        public async Task<Response<IEnumerable<GetInventoriesResponse>>> Handle(GetInventoriesListQuery request, CancellationToken cancellationToken)
        {
            var inventories = await _inventoryService.GetListAsync();

            var inventoriesList = _mapper.Map<IEnumerable<GetInventoriesResponse>>(inventories);

            return Success(inventoriesList);
        }

        public async Task<Response<GetInventoriesResponse>> Handle(GetInventoriesByLocationQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Location) && string.IsNullOrWhiteSpace(request.Location))
                return BadRequest<GetInventoriesResponse>(nameof(request.Location) + ": " + _stringLocalizer[SharedResourcesKeys.NotEmpty]);

            var inventory = await _inventoryService.GetInventoryByLocationAsync(request.Location);

            if (inventory == null) return NotFound<GetInventoriesResponse>();

            var inventoryMapper = _mapper.Map<GetInventoriesResponse>(inventory);

            return Success(inventoryMapper);
        }
    }
}

