using AutoMapper;
using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Result<Unit>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, ILogger<DeleteCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null) return Result<Unit>.Failure("");

            _mapper.Map(request.Category, category);

            await _categoryRepository.UpdateAsync(category);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
