using API.Base;
using Core.Featurs.PaymentMethods.Commands.Requests;
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
        return NewResult(response);
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
    [HttpGet]
    [Route(Router.PaymentMethodRouting.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymentMethod>> GetPaymentMethodById([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetPaymentMethodByIdRequest(id));
        return NewResult(response);
    }

    [HttpPost]
    [Route(Router.PaymentMethodRouting.Add)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<PaymentMethod>> AddPaymentMethod(
        [FromBody] CreatePaymentMethodCommand createPaymentMethodCommand)
    {
        var response = await _mediator.Send(createPaymentMethodCommand);
        return NewResult(response);
    }
    [HttpPut]
    [Route(Router.PaymentMethodRouting.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<PaymentMethod>> UpdatePaymentMethod([FromRoute] long id,
        [FromBody] PaymentMethodBaseCommand baseCommand)
    {
        var command = new UpdatePaymentMethodCommand
        {
            Id = id,
            Name = baseCommand.Name
        };
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete]
    [Route(Router.PaymentMethodRouting.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaymentMethod>> DeletePaymentMethod([FromRoute] long id)
    {
        var command = new DeletePaymentMethodByIdCommand
        {
            Id = id
        };
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
}