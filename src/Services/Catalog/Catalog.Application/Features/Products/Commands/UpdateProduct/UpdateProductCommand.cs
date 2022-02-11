using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Products.Commands
{
    public class UpdateProductCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public ProductDto Product { get; set; }
    }
}
