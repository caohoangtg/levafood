using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Products.Queries
{
    public class GetProductsPagedQuery : IRequest<Result<PagedList<ProductDto>>>
    {
        public PagingParams PagingParams { get; set; }
    }
}
