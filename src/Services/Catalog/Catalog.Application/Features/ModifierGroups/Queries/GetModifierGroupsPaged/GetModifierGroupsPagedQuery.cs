using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.ModifierGroups.Queries
{
    public class GetModifierGroupsPagedQuery : IRequest<Result<PagedList<ModifierGroupDto>>>
    {
        public PagingParams PagingParams { get; set; }
    }
}
