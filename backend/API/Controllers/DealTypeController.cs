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
        [Route(Router.DealTypeRouting.List)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DealType>> GetDealTypeList()
        {
            var response = await _mediator.Send(new GetDealTypesListRequest());
            return NewResult(response);
        }
    }
}
