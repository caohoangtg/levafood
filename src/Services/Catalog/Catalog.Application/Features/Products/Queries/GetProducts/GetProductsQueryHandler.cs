using AutoMapper;
using Catalog.Application.Models.Results;
using Catalog.Application.ViewModels;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, Result<List<ProductViewModel>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductsQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<List<ProductViewModel>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var modifierGroups = await _productRepository.GetAllAsync();

            return Result<List<ProductViewModel>>.Success(_mapper.Map<List<ProductViewModel>>(modifierGroups));
        }
    }
}
