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
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Result<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetProductQueryHandler> _logger;

        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductQueryHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            List<Expression<Func<Product, object>>> includes = new()
            {
                m => m.Modifiers,
                m => m.Category,
                m => m.ModifierGroups,
                m => m.Photos,
                m => m.Variants
            };

            //Expression<Func<Product, bool>> predicate = m => m.Name == "Topping"
            //    && (m.Modifiers.Any() || m.Products.Any())
            //    && m.CreatedBy == "HoangTC";

            var product = await _productRepository.GetByIdAsync(request.Id, null, includes);

            if (product == null) return Result<ProductDto>.Failure("Failure");

            return Result<ProductDto>.Success(_mapper.Map<ProductDto>(product));
        }
    }
}
