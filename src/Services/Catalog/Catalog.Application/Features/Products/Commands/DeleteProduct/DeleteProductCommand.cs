using Catalog.Application.Models.Results;
using MediatR;
namespace Catalog.Application.Features.Products.Commands
{
    public class DeleteProductCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
}
