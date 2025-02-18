using API.Base;
using Core.Featurs.PaymentMethods.Query.Request;
using Data.AppMetaData;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
public class PaymentMethodsController(IMediator mediator) : AppBaseController(mediator)
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [Route(Router.PaymentMethodRouting.List)]
    public async Task<ActionResult<PaymentMethod>> GetPaymentMethodsList()
    {
        var response = await _mediator.Send(new GetPaymentMethodsListRequest());
        return Ok(response);
    }
    [HttpGet]
    [Route(Router.PaymentMethodRouting.GetByName)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymentMethod>> GetPaymentMethodByName([FromRoute] string name)
    {
        var response = await _mediator.Send(new GetPaymentMethodByNameRequest(name));
        return NewResult(response);
    }
}