using API.Base;
using Core.Featurs.Inventories.Commands.Requests;
using Core.Featurs.Inventories.Queries.Requests;
using Data.AppMetaData;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [ApiController]
    public class InventoryController : AppBaseController
    {


        public InventoryController(IMediator mediator) : base(mediator)
        {

        }


        [HttpGet]
        [Route(Router.InventoryRoutes.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Inventory>> GetInventoryById([FromRoute]int id)
        {
            var response = await _mediator.Send(new GetInventoriesById(id));

            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.InventoryRoutes.List)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<Inventory>> GetInventoriesList()
        {
            var response = await _mediator.Send(new GetInventoriesListQuery());

            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.InventoryRoutes.GetByLocation)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<Inventory>> GetInventoryByLocation(string location)
        {
            var response = await _mediator.Send(new GetInventoriesByLocationQuery(location));

            return NewResult(response);
        }

        [HttpPut]
        [Route(Router.InventoryRoutes.Update)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult<Inventory>> UpdateInventory([FromRoute] long id, 
            [FromBody] InventoryBaseCommand inventoryCommand)
        {
            var updateCommand = new UpdateInventoryCommand 
            {
                Id = id,
                Location = inventoryCommand.Location, 
                Quantity = inventoryCommand.Quantity,
            };

            var response = await _mediator.Send(updateCommand);

            return NewResult(response);
        }

        [HttpDelete]
        [Route(Router.InventoryRoutes.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Inventory>> DeleteInventory([FromRoute] int id)
        {
            var response = await _mediator.Send(new DeleteInventoryCommand {Id = id });

            return NewResult(response);
        }

        [HttpPost]
        [Route(Router.InventoryRoutes.Create)]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult<Inventory>> Create([FromBody] CreateInventoryCommand inventoryCommand)
        {
            var response = await _mediator.Send(inventoryCommand);

            return NewResult(response);
        }
    }
}
