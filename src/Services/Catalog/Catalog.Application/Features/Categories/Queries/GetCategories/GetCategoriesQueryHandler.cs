using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Catalog.Application.Features.Categories.Queries
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, Result<List<CategoryDto>>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoriesQueryHandler> _logger;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<GetCategoriesQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<List<CategoryDto>>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Category, bool>> predicate = m => m.IsActivated && !m.IsDeleted;
            var categories = await _categoryRepository.GetAsync(predicate);

            return Result<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories));
        }
    }
}
