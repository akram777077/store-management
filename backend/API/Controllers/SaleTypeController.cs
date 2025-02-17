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
}