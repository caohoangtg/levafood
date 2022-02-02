using Catalog.Application.Features.ModifierGroups.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Catalog.API.Controllers
{
    public class ModifierGroupController : BaseApiController
    {
        #region Command

        [HttpPost(Name = "CreateModifierGroup")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> CreateModifierGroup([FromBody] CreateModifierGroupCommand command)
        {
            return HandleResult(await Mediator.Send(command));
        }

        #endregion
    }
}
