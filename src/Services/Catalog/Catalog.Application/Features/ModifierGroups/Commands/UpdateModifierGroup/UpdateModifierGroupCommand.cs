using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Catalog.Application.Features.ModifierGroups.Commands
{
    public class UpdateModifierGroupCommand : IRequest<Result<Unit>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public ModifierGroupDto ModifierGroup { get; set; }
    }
}
