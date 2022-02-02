using Catalog.Application.DTOs;
using Catalog.Application.Features.Categories.Commands;
using Catalog.Application.Features.Categories.Queries;
using Catalog.Application.Models.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    public class CategoryController : BaseApiController
    {
        #region Command

        [HttpPost]
        [Route("CreateCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("UpdateCategory/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryCommand command)
        {
            command.Id = id;
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteCategoryCommand { Id = id }));
        }

        #endregion

        #region Query

        [HttpGet]
        [Route("GetCategory/{id}")]
        [ProducesResponseType(typeof(CategoryDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetCategory(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetCategoryQuery { Id = id }));
        }

        [HttpGet]
        [Route("GetCategories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetCategories()
        {
            return HandleResult(await Mediator.Send(new GetCategoriesQuery()));
        }

        [HttpGet]
        [Route("GetCategoriesPaged")]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetCategoriesPaged([FromQuery] PagingParams pagingParams)
        {
            return HandleResult(await Mediator.Send(new GetCategoriesPagedQuery { PagingParams = pagingParams }));
        }

        #endregion
    }
}
