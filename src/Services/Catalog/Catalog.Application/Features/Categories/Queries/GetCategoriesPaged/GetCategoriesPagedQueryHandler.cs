using AutoMapper;
using AutoMapper.QueryableExtensions;
using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Catalog.Application.Features.Categories.Queries
{
    public class GetCategoriesPagedQueryHandler : IRequestHandler<GetCategoriesPagedQuery, Result<PagedList<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoriesPagedQueryHandler> _logger;

        public GetCategoriesPagedQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<GetCategoriesPagedQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<PagedList<CategoryDto>>> Handle(GetCategoriesPagedQuery request, CancellationToken cancellationToken)
        {
            //List<Expression<Func<Category, object>>> includes = new() { m => m.Products };
            Expression<Func<Category, bool>> predicate = m => m.Name == request.PagingParams.Search;

            var query = _categoryRepository.GetAsQueryable(predicate)
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider);

            var categoriesPaged = await PagedList<CategoryDto>.CreateAsync(query, request.PagingParams.PageNumber, request.PagingParams.PageSize, request.PagingParams.Search);

            return Result<PagedList<CategoryDto>>.Success(categoriesPaged);
        }
    }
}
