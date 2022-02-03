using Catalog.Application.ViewModels;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.ModifierGroups.Queries
{
    public class GetModifierGroupsQuery : IRequest<Result<List<ModifierGroupViewModel>>>
    {
    }
}
