using API.Base;
using Core.Featurs.DealTypes.Commands.Requests;
using Core.Featurs.DealTypes.Query.Request;
using Data.AppMetaData;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class DealTypeController(IMediator mediator) : AppBaseController(mediator)
    {
        [HttpGet]
        [Route(Router.DealTypeRouting.GetById)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DealType>> GetDealTypeById(int id)
        {
            var response = await _mediator.Send(new GetDealTypeByIdRequest(id));
            return NewResult(response);
        }
        [HttpGet]
        [Route(Router.DealTypeRouting.GetByName)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DealType>> GetDealTypeByName(string name)
        {
            var response = await _mediator.Send(new GetDealTypeByNameRequest(name));
            return NewResult(response);
        }
        [HttpPost]
        [Route(Router.DealTypeRouting.Create)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<DealType>> CreateDealType([FromBody] CreateDealTypeCommand createDealTypeCommand)
        {
            var response = await _mediator.Send(createDealTypeCommand);
            return NewResult(response);
        }
        [HttpPut]
        [Route(Router.DealTypeRouting.Update)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<DealType>> UpdateDealType(int id, [FromBody] DealTypeBaseCommand baseCommand)
        {
            var updateDealTypeCommand = new UpdateDealTypeCommand
            {
                Id = id,
                Name = baseCommand.Name,
            };
            var response = await _mediator.Send(updateDealTypeCommand);
            return NewResult(response);
        }
        [HttpGet]
        [Route(Router.DealTypeRouting.List)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DealType>> GetDealTypeList()
        {
            var response = await _mediator.Send(new GetDealTypesListRequest());
            return NewResult(response);
        }
        [HttpDelete]
        [Route(Router.DealTypeRouting.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DealType>> DeleteDealType(int id)
        {
            var command = new DeleteDealTypeByIdCommand { Id = id };
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
