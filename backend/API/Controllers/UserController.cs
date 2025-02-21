using API.Base;
using Core.Featurs.Users.Commands.Requests;
using Core.Featurs.Users.Queries.Request;
using Data.AppMetaData;
using Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class UserController : AppBaseController
    {
        public UserController(IMediator mediator) : base(mediator)
        {
        }
        //---------------Commands-----------------//

        [HttpPost]
        [Route(Router.UserRouting.Create)]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> Create([FromBody] CreateUserCommand userCommand)
        {
            var response = await _mediator.Send(userCommand);
            return NewResult(response);
        }

        [HttpPut(Router.UserRouting.Update)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Edit([FromRoute] string Id
            ,[FromBody] UpdateUserBaseCommand baseCommand)
        {
            UpdateUserCommand command = new UpdateUserCommand
            {
                Id = Id,
                UserName = baseCommand.UserName,
                Email = baseCommand.Email,
                PhoneNumber = baseCommand.PhoneNumber
            };
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpPut(Router.UserRouting.ChangePassword)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ResetPassword([FromRoute] string Id
            , [FromBody] ResetPasswordBaseCommand baseCommand)
        {
            ResetPasswordCommand command = new ResetPasswordCommand
            {
                Id = Id,
                CurrentPassword = baseCommand.CurrentPassword,
                NewPassword = baseCommand.NewPassword,
                ConfirmPassword = baseCommand.ConfirmPassword
            };
            var response = await _mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete]
        [Route(Router.UserRouting.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> Delete([FromRoute] string Id)
        {
            var response = await _mediator.Send(new DeleteUserCommand { Id = Id });
            return NewResult(response);
        }

        [HttpPatch]
        [Route(Router.UserRouting.UnDelete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> UnDelete([FromRoute] string Id)
        {
            var response = await _mediator.Send(new UnDeleteUserCommad { Id = Id });
            return NewResult(response);
        }

        //---------------Queries-----------------//

        [HttpGet]
        [Route(Router.UserRouting.List)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<User>> GetUsersList([FromQuery] GetUsersListQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet]
        [Route(Router.UserRouting.GetById)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> GetUserById([FromRoute] string Id)
        {
            var response = await _mediator.Send(new GetUserByIdQuery { Id = Id });
            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.UserRouting.GetByUsername)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> GetUserByUsername([FromRoute] string Username)
        {
            var response = await _mediator.Send(new GetUserByUsernameQuery { Username = Username });
            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.UserRouting.GetByPhoneNumber)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> GetUserByPhoneNumber([FromRoute] string PhoneNumber)
        {
            var response = await _mediator.Send(new GetUserByPhoneNumberQuery { PhoneNumber = PhoneNumber });
            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.UserRouting.GetByEmail)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> GetUserByEmail([FromRoute] string Email)
        {
            var response = await _mediator.Send(new GetUserByEmailQuery { Email = Email });
            return NewResult(response);
        }
    }
}
