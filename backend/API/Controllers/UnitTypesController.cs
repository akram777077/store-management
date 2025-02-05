using API.Base;
using Core.Featurs.UnitType.Commands.Requests;
using Core.Featurs.UnitType.Query.Request;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UnitType>> GetUnitTypesList()
        {
            var response = await _mediator.Send(new GetUnitTypesListRequest());
            return NewResult(response);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route(Router.UnitTypesRoute.GetUnitTypeByName)]
        public async Task<ActionResult<UnitType>> GetUnitTypeByName(string name)
        {
            var response = await _mediator.Send(new GetUnitTypeByNameRequest(name));
            return NewResult(response);
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route(Router.UnitTypesRoute.GetUnitTypeById)]
        public async Task<ActionResult<UnitType>> GetUnitTypeById(long id)
        {
            var response = await _mediator.Send(new GetUnitTypeByIdRequest(id));
            return NewResult(response);
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UnitType>> CreateUnitType([FromBody]UnitTypeNameOnlyCommand unitTypeNameOnlyCommand)
        {
            var response = await _mediator.Send(unitTypeNameOnlyCommand);
            return NewResult(response);
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route(Router.UnitTypesRoute.DeleteById)]
        public async Task<ActionResult<UnitType>> DeleteUnitTypeByName(int id)
        {
            var command = new DeleteUnitTypeByIdCommand { Id = id };
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [Route(Router.UnitTypesRoute.UpdateById)]
        public async Task<ActionResult<UnitType>> UpdateUnitTest(
            long id,
            [FromBody] UnitTypeNameOnlyCommand command
            )
        {
            var request = new UpdateUnitTypeCommand { Id = id, Name = command.Name };
            var response = await _mediator.Send(request);
            return NewResult(response);
        }
    }
}
