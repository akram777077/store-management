using API.Base;
using Core.Featurs.Brands.Commands.Requests;
using Core.Featurs.Brands.Query.Request;
using Data.AppMetaData;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
[ApiController]
public class BrandController(IMediator mediator) : AppBaseController(mediator)
{
    [HttpGet]
    [Route(Router.BrandRoute.GetBrands)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Brand>> GetBrandsList()
    {
        var response = await _mediator.Send(new GetBrandListRequest());
        return NewResult(response);
    }
    [HttpGet]
    [Route(Router.BrandRoute.GetById)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Brand>> GetBrandById([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetBrandByIdRequest(id));
        return NewResult(response);
    }
    [HttpPut]
    [Route(Router.BrandRoute.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Brand>> UpdateBrand(int id,[FromBody] BrandBaseCommand request)
    {
        var updateRequest = new UpdateBrandCommand
        {
            Id = id,
            Name = request.Name
        };
        var response = await _mediator.Send(updateRequest);
        return NewResult(response);
    }
    [HttpPost]
    [Route(Router.BrandRoute.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<ActionResult<Brand>> CreateBrand([FromBody] CreateBrandCommand createBrandCommand)
    {
        var response = await _mediator.Send(createBrandCommand);
        return NewResult(response);
    }
    [HttpDelete]
    [Route(Router.BrandRoute.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Brand>> DeleteBrand(int id)
    {
        var request = new DeleteBrandByIdCommand
        {
            Id = id
        };
        var response = await _mediator.Send(request);
        return NewResult(response);
    }
}