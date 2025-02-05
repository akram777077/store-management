using Core.Bases;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace API.Base
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AppBaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public AppBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //private IMediator _mediatorInstance;
        //protected IMediator Mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();

        #region Actions
        public ActionResult NewResult<T>(Response<T> response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    return new OkObjectResult(response);
                case HttpStatusCode.Created:
                    return new CreatedResult(string.Empty, response);
                case HttpStatusCode.Conflict:
                    return new ConflictObjectResult(response);
                case HttpStatusCode.Unauthorized:
                    return new UnauthorizedObjectResult(response);
                case HttpStatusCode.BadRequest:
                    return new BadRequestObjectResult(response);
                case HttpStatusCode.NotFound:
                    return new NotFoundObjectResult(response);
                case HttpStatusCode.Accepted:
                    return new AcceptedResult(string.Empty, response);
                case HttpStatusCode.UnprocessableEntity:
                    return new UnprocessableEntityObjectResult(response);
                case HttpStatusCode.NoContent:
                    return new NoContentResult();
                default:
                    return new NotFoundObjectResult(response);
            }
        }
        #endregion
    }
}
