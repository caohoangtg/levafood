using Catalog.Application.Features.Categories.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    public class CategoryController : BaseApiController
    {
        #region Command

        [HttpPost(Name = "CreateCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        #endregion
    }
}
