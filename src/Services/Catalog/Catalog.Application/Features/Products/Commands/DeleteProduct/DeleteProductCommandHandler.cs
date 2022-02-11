using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Commands
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Result<Unit>>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<DeleteProductCommandHandler> _logger;

        public DeleteProductCommandHandler(IProductRepository productRepository, ILogger<DeleteProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Remove Product");
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null) return Result<Unit>.Failure("Fail");

            product.Remove();

            await _productRepository.UpdateAsync(product);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
