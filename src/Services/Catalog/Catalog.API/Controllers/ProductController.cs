using Catalog.Application.DTOs;
using Catalog.Application.Features.Products.Commands;
using Catalog.Application.Features.Products.Queries;
using Catalog.Application.Models.Results;
using Catalog.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    public class ProductController : BaseApiController
    {
        #region Command

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        [HttpPut]
        [Route("UpdateProduct/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
        {
            command.Id = id;
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteProduct/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteProductCommand { Id = id }));
        }

        #endregion

        #region Query

        [HttpGet]
        [Route("GetProduct/{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProduct(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetProductQuery { Id = id }));
        }

        [HttpGet]
        [Route("GetProducts")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProducts()
        {
            return HandleResult(await Mediator.Send(new GetProductsQuery()));
        }
        
        [HttpGet]
        [Route("GetProductsByCategory/{categoryId}")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProductsByCategory(Guid categoryId)
        {
            return HandleResult(await Mediator.Send(new GetProductsByCategoryQuery { CategoryId = categoryId }));
        }

        [HttpGet]
        [Route("GetProductsPaged")]
        [ProducesResponseType(typeof(IEnumerable<ProductViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetProductsPaged([FromQuery] PagingParams pagingParams)
        {
            return HandleResult(await Mediator.Send(new GetProductsPagedQuery { PagingParams = pagingParams }));
        }

        #endregion
    }
}
