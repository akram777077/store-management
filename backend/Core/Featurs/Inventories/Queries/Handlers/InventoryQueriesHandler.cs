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
        IRequestHandler<GetInventoriesById, Response<GetInventoriesResponse>>
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
    }
}
