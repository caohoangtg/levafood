﻿using Catalog.Application.Features.Products.Commands;
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

        #endregion
    }
}
