using API.Base;
using Core.Featurs.Categories.Commands.Requests;
using Core.Featurs.Categories.Queries.Resquests;
using Data.AppMetaData;
using Data.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class CategoriesController : AppBaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet(Router.CategoryRouteing.List)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Category>> GetCategoriesList()
        {
            var response = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(response);
        }

        [HttpGet]
        [Route(Router.CategoryRouteing.GetById)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> GetCategoryById([FromRoute] int id)
        {
            var response = await _mediator.Send(new GetCategoriesByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet]
        [Route(Router.CategoryRouteing.GetByName)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Category>> GetCategoryByName([FromRoute] string name)
        {
            var response = await _mediator.Send(new GetCategoryByNameQuery(name));
            return NewResult(response);
        }

        [HttpPost]
        [Route(Router.CategoryRouteing.Create)]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Category>> Create([FromBody] CreateCategoryCommand categoryCommand)
        {
            var response = await _mediator.Send(categoryCommand);
            return NewResult(response);
        }

        [HttpPut]
        [Route(Router.CategoryRouteing.Update)]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<Category>> UpdateCategory([FromRoute] long id,
            [FromBody] CategoryBaseCommand baseCommande)
        {
            var categoryCommande = new UpdateCategoryCommand { Id = id, Name = baseCommande.Name, Description = baseCommande.Description };
            var response = await _mediator.Send(categoryCommande);
            return NewResult(response);
        }

        [HttpDelete]
        [Route(Router.CategoryRouteing.Delete)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Category>> DeleteCategory([FromRoute] int Id)
        {
            var response = await _mediator.Send(new DeleteCategoryCommand { Id = Id });
            return NewResult(response);
        }
    }
}
