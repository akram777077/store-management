using API.Base;
using Core.Featurs.UnitTypes.Commands.Requests;
using Core.Featurs.UnitTypes.Query.Request;
using Data.AppMetaData;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route(Router.UnitTypesRoute.Prefix)]
    [ApiController]
    public class UnitTypesController(IMediator mediator) : AppBaseController(mediator)
    {
        [HttpGet]
        [Route(Router.UnitTypesRoute.List)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitType>> GetUnitTypesList()
        {
            var response = await _mediator.Send(new GetUnitTypesListRequest());
            return NewResult(response);
        }
        [HttpGet]
        [Route(Router.UnitTypesRoute.GetByName)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UnitType>> GetUnitTypeByName(string name)
        {
            var response = await _mediator.Send(new GetUnitTypeByNameRequest(name));
            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.UnitTypesRoute.GetById)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UnitType>> GetUnitTypeById(long id)
        {
            var response = await _mediator.Send(new GetUnitTypeByIdRequest(id));
            return NewResult(response);
        }
        [HttpPost]
        [Route(Router.UnitTypesRoute.Create)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UnitType>> CreateUnitType([FromBody]CreateUnitTypeCommand createUnitTypeCommand)
        {
            var response = await _mediator.Send(createUnitTypeCommand);
            return NewResult(response);
        }

        [HttpDelete]
        [Route(Router.UnitTypesRoute.Delete)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UnitType>> DeleteUnitType(int id)
        {
            var command = new DeleteUnitTypeByIdCommand { Id = id };
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut]
        [Route(Router.UnitTypesRoute.Update)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UnitType>> UpdateUnitTest(
            long id,
            [FromBody] UnitTypeBaseCommand command
            )
        {
            var request = new UpdateUnitTypeCommand { Id = id, Name = command.Name };
            var response = await _mediator.Send(request);
            return NewResult(response);
        }
    }
}
