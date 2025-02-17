using API.Base;
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
}