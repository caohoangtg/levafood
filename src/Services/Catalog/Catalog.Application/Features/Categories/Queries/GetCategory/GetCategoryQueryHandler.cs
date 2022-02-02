using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Categories.Queries
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Result<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetCategoryQueryHandler> _logger;

        public GetCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<GetCategoryQueryHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null) return Result<CategoryDto>.Failure("");

            return Result<CategoryDto>.Success(_mapper.Map<CategoryDto>(category));
        }
    }
}
