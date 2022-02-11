using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Products.Queries
{
    public class GetProductQuery : IRequest<Result<ProductDto>>
    {
        public Guid Id { get; set; }
    }
}
