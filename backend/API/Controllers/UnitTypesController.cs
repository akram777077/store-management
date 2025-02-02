using API.Base;
using Core.Featurs.UnitType.Query.Request;
using Data.AppMetaData;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route(Router.UnitTypesRoute.prefix)]
    [ApiController]
    public class UnitTypesController(IMediator mediator) : AppBaseController(mediator)
    {
        [HttpGet]
        public async Task<ActionResult<UnitType>> GetUnitTypesList()
        {
            var response = await _mediator.Send(new GetUnitTypesListRequest());
            return NewResult(response);
        }
    }
}
