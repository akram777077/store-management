using API.Base;
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
}