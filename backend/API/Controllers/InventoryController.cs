using API.Base;
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
    }
}
