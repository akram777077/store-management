using AutoMapper;
using Core.Bases;
using Core.Featurs.Inventories.Commands.Requests;
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

namespace Core.Featurs.Inventories.Commands.Handlers
{
    public class InventoryCommandsHandler : ResponseHandler,
        IRequestHandler<UpdateInventoryCommand, Response<string>>,
        IRequestHandler<DeleteInventoryCommand, Response<string>>,
        IRequestHandler<CreateInventoryCommand, Response<string>>

    {
        private readonly IStringLocalizer _stringLocalizer;
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public InventoryCommandsHandler(IStringLocalizer<SharedResources> stringLocalizer, IInventoryService inventoryService, IMapper mapper) 
            : base(stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = await _inventoryService.GetByIdAsync(request.Id);

            if (inventory == null) return NotFound<string>();

            _mapper.Map(request, inventory);

            await _inventoryService.UpdateAsync(inventory);

            return Success("");
        }

        public async Task<Response<string>> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            // validate the id
            if (request.Id <= 0)
                return BadRequest<string>(_stringLocalizer[SharedResourcesKeys.IdGreaterThanZero]);

            var inventory = await _inventoryService.GetByIdAsync(request.Id);

            // validate if the inventory is exists or not
            if (inventory == null) return NotFound<string>();

            // delete the inventory
            var response = await _inventoryService.DeleteAsync(inventory);

            if (response == "Deleted") return Deleted<string>("");

            return InternalServerError<string>();
        }

        public async Task<Response<string>> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            var inventory = _mapper.Map<Inventory>(request);

            var response = await _inventoryService.AddAsync(inventory);

            return Created("");
        }
    }
}
