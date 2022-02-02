using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<Result<Unit>>
    {
        public ProductDto Product { get; set; }
    }
}
