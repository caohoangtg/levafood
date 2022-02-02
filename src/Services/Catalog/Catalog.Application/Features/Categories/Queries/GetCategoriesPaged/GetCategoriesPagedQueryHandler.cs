using AutoMapper;
using AutoMapper.QueryableExtensions;
using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Categories.Queries
{
    public class GetCategoriesPagedQueryHandler : IRequestHandler<GetCategoriesPagedQuery, Result<PagedList<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoryQueryHandler> _logger;

        public GetCategoriesPagedQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<GetCategoryQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<PagedList<CategoryDto>>> Handle(GetCategoriesPagedQuery request, CancellationToken cancellationToken)
        {
            var query = _categoryRepository.GetAsQueryable()
                .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider);

            var categoriesPaged = await PagedList<CategoryDto>.CreateAsync(query, request.PagingParams.PageNumber, request.PagingParams.PageSize);

            return Result<PagedList<CategoryDto>>.Success(categoriesPaged);
        }
    }
}
