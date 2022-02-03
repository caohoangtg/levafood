using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.ModifierGroups.Queries
{
    public class GetModifierGroupQuery : IRequest<Result<ModifierGroupDto>>
    {
        public Guid Id { get; set; }
    }
}
