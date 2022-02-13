using Catalog.API.Extensions;
using Catalog.Application.Models.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if (result == null)
            {
                return NotFound();
            }

            if (result.IsSuccess)
            {
                if (result.Value == null)
                {
                    return NotFound();
                }

                return Ok(result.Value);
            }

            return BadRequest(result.Error);
        }

        protected ActionResult HandlePagedResult<T>(Result<PagedList<T>> result)
        {
            if (result == null)
            {
                return NotFound();
            }

            if (result.IsSuccess)
            {
                if (result.Value == null)
                {
                    return NotFound();
                }

                Response.AddPaginationHeader(
                    result.Value.CurrentPage, 
                    result.Value.PageSize, 
                    result.Value.TotalCount, 
                    result.Value.TotalPages, 
                    result.Value.Search
                    );
                return Ok(result.Value);
            }

            return BadRequest(result.Error);
        }
    }
}
