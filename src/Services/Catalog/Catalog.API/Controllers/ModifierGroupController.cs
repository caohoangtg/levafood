using Catalog.Application.DTOs;
using Catalog.Application.Features.ModifierGroups.Commands;
using Catalog.Application.Features.ModifierGroups.Queries;
using Catalog.Application.Models.Results;
using Catalog.Application.ViewModels;
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

        [HttpPut]
        [Route("UpdateModifierGroup/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> UpdateModifierGroup(Guid id, [FromBody] UpdateModifierGroupCommand command)
        {
            command.Id = id;
            return HandleResult(await Mediator.Send(command));
        }

        [HttpDelete]
        [Route("DeleteModifierGroup/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> DeleteModifierGroup(Guid id)
        {
            return HandleResult(await Mediator.Send(new DeleteModifierGroupCommand { Id = id }));
        }

        #endregion

        #region Query

        [HttpGet]
        [Route("GetModifierGroup/{id}")]
        [ProducesResponseType(typeof(ModifierGroupDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetModifierGroup(Guid id)
        {
            return HandleResult(await Mediator.Send(new GetModifierGroupQuery { Id = id }));
        }

        [HttpGet]
        [Route("GetModifierGroups")]
        [ProducesResponseType(typeof(IEnumerable<ModifierGroupViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetModifierGroups()
        {
            return HandleResult(await Mediator.Send(new GetModifierGroupsQuery()));
        }

        [HttpGet]
        [Route("GetModifierGroupsPaged")]
        [ProducesResponseType(typeof(IEnumerable<ModifierGroupViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult> GetModifierGroupsPaged([FromQuery] PagingParams pagingParams)
        {
            return HandleResult(await Mediator.Send(new GetModifierGroupsPagedQuery { PagingParams = pagingParams }));
        }

        #endregion
    }
}
