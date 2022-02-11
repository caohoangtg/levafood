using AutoMapper;
using AutoMapper.QueryableExtensions;
using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Products.Queries
{
    public class GetProductsPagedQueryHandler : IRequestHandler<GetProductsPagedQuery, Result<PagedList<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsQueryHandler> _logger;

        public GetProductsPagedQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductsQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<PagedList<ProductDto>>> Handle(GetProductsPagedQuery request, CancellationToken cancellationToken)
        {
            var query = _productRepository.GetAsQueryable()
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider);

            var productsPaged = await PagedList<ProductDto>.CreateAsync(query, request.PagingParams.PageNumber, request.PagingParams.PageSize);

            return Result<PagedList<ProductDto>>.Success(productsPaged);
        }
    }
}
