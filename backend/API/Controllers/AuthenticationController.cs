using API.Base;
using Core.Featurs.Authentication.Commands.Request;
using Core.Featurs.Authentication.Queries.Requests;
using Data.AppMetaData;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class AuthenticationController : AppBaseController
    {
        public AuthenticationController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        [Route(Router.AuthenticationRouting.SignIn)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> SignIn([FromForm] SignInCommand singInCommand)
        {
            var response = await _mediator.Send(singInCommand);
            return NewResult(response);
        }

        [HttpPost]
        [Route(Router.AuthenticationRouting.RefreshToken)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> RefreshToken([FromForm] RefreshTokenCommand refreshTokenCommand)
        {
            var response = await _mediator.Send(refreshTokenCommand);
            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.AuthenticationRouting.ValidateToken)]

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> ValidateToken([FromQuery] CheckTokenExpiryQuery checkTokenExpiryQuery)
        {
            var response = await _mediator.Send(checkTokenExpiryQuery);
            return NewResult(response);
        }
    }
}
