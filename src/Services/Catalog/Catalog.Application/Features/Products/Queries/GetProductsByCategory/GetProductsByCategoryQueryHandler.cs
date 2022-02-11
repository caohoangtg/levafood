using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Catalog.Application.Features.Products.Queries
{
    public class GetProductsByCategoryQueryHandler : IRequestHandler<GetProductsByCategoryQuery, Result<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductsByCategoryQueryHandler> _logger;

        public GetProductsByCategoryQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductsByCategoryQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<List<ProductDto>>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Expression<Func<Product, object>>> includes = new()
            {
                m => m.Modifiers,
                m => m.Category,
                m => m.ModifierGroups,
                m => m.Photos,
                m => m.Variants
            };

            Expression<Func<Product, bool>> predicate = m => m.CategoryId == request.CategoryId;

            var products = await _productRepository.GetAsync(predicate, null, includes);

            if (products == null) return Result<List<ProductDto>>.Failure("Failure");

            return Result<List<ProductDto>>.Success(_mapper.Map<List<ProductDto>>(products));
        }
    }
}
