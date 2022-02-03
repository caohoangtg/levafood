using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.ModifierGroups.Commands
{
    public class DeleteModifierGroupCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
}
