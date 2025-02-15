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
    public async Task<ActionResult<Brand>> GetBrandsList()
    {
        var response = await _mediator.Send(new GetBrandListRequest());
        return NewResult(response);
    }
    [HttpGet]
    [Route(Router.BrandRoute.GetById)]
    public async Task<ActionResult<Brand>> GetBrandById([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetBrandByIdRequest(id));
        return NewResult(response);
    }
    [HttpPut]
    [Route(Router.BrandRoute.Update)]
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
}