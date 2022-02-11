using AutoMapper;
using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<Unit>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper, ILogger<UpdateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null) return Result<Unit>.Failure("");

            _mapper.Map(request.Product, product);

            await _productRepository.UpdateAsync(product);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
