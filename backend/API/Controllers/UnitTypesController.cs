using API.Base;
using Core.Featurs.UnitType.Commands.Requests;
using Core.Featurs.UnitType.Query.Request;
using Data.AppMetaData;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route(Router.UnitTypesRoute.Prefix)]
    [ApiController]
    public class UnitTypesController(IMediator mediator) : AppBaseController(mediator)
    {
        [HttpGet]
        public async Task<ActionResult<UnitType>> GetUnitTypesList()
        {
            var response = await _mediator.Send(new GetUnitTypesListRequest());
            return NewResult(response);
        }
        [HttpGet]
        [Route(Router.UnitTypesRoute.GetUnitTypeByName)]
        public async Task<ActionResult<UnitType>> GetUnitTypeByName(string name)
        {
            var response = await _mediator.Send(new GetUnitTypeByNameRequest(name));
            return NewResult(response);
        }
        [HttpGet]
        [Route(Router.UnitTypesRoute.GetUnitTypeById)]
        public async Task<ActionResult<UnitType>> GetUnitTypeById(long id)
        {
            var response = await _mediator.Send(new GetUnitTypeByIdRequest(id));
            return NewResult(response);
        }
        [HttpPost]
        public async Task<ActionResult<UnitType>> CreateUnitType([FromBody]CreateUnitTypeCommand unitTypeCommand)
        {
            var response = await _mediator.Send(unitTypeCommand);
            return NewResult(response);
        }
    }
}
