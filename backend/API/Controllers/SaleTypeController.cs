using API.Base;
using Core.Featurs.SaleTypes.Commands.Requests;
using Core.Featurs.SaleTypes.Query.Requests;
using Data.AppMetaData;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
public class SaleTypeController(IMediator mediator) : AppBaseController(mediator)
{
    [HttpGet]
    [Route(Router.SaleTypeRouting.List)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<SaleType>> GetSaleTypeList()
    {
        var response = await _mediator.Send(new GetSaleTypesListQuery());
        return Ok(response);
    }
    [HttpGet]
    [Route(Router.SaleTypeRouting.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SaleType>> GetSaleTypeById(long id)
    {
        var response = await _mediator.Send(new GetSaleTypeByIdQuery(id));
        return NewResult(response);
    }
    [HttpGet]
    [Route(Router.SaleTypeRouting.GetByName)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<SaleType>> GetSaleTypeByName(string name)
    {
        var response = await _mediator.Send(new GetSaleTypeByNameQuery(name));
        return NewResult(response);
    }
    [HttpPost]
    [Route(Router.SaleTypeRouting.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<SaleType>> CreateSaleType([FromBody] CreateSaleTypeCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut]
    [Route(Router.SaleTypeRouting.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<SaleType>> UpdateSaleType(long id, [FromBody] SaleTypeBaseCommand command)
    {
        var commandUpdate = new UpdateSaleTypeCommand
        {
            Id = id,
            Name = command.Name,
            Description = command.Description
        };
        var response = await _mediator.Send(commandUpdate);
        return NewResult(response);
    }
    [HttpDelete]
    [Route(Router.SaleTypeRouting.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<SaleType>> DeleteSaleType(long id)
    {
        var command = new DeleteSaleTypeCommand
        {
            Id = id
        };
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
}