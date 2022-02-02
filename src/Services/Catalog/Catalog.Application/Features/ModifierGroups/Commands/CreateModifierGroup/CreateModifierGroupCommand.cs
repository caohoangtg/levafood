using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.ModifierGroups.Commands
{
    public class CreateModifierGroupCommand : IRequest<Result<Unit>>
    {
        public ModifierGroupDto ModifierGroup { get; set; }
    }
}
