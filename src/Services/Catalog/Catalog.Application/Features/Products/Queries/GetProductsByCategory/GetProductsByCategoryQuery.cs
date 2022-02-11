using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Products.Queries
{
    public class GetProductsByCategoryQuery : IRequest<Result<List<ProductDto>>>
    {
        public Guid CategoryId { get; set; }
    }
}
