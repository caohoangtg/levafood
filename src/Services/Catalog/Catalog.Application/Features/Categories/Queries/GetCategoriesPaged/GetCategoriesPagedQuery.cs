using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Categories.Queries
{
    public class GetCategoriesPagedQuery : IRequest<Result<PagedList<CategoryDto>>>
    {
        public PagingParams PagingParams { get; set; }
    }
}
