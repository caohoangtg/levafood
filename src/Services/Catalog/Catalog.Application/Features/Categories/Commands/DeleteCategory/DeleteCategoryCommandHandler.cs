using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.Categories.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Result<Unit>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<DeleteCategoryCommandHandler> _logger;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, ILogger<DeleteCategoryCommandHandler> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Remove Category");
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null) return Result<Unit>.Failure("");

            category.Remove();

            await _categoryRepository.UpdateAsync(category);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
