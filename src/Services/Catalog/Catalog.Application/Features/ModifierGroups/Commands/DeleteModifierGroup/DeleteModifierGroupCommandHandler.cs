using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.ModifierGroups.Commands
{
    public class DeleteModifierGroupCommandHandler : IRequestHandler<DeleteModifierGroupCommand, Result<Unit>>
    {
        private readonly IModifierGroupRepository _modifierGroupRepository;
        private readonly ILogger<DeleteModifierGroupCommandHandler> _logger;

        public DeleteModifierGroupCommandHandler(IModifierGroupRepository modifierGroupRepository, ILogger<DeleteModifierGroupCommandHandler> logger)
        {
            _modifierGroupRepository = modifierGroupRepository;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(DeleteModifierGroupCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Remove Category");
            var modifierGroup = await _modifierGroupRepository.GetByIdAsync(request.Id);

            if (modifierGroup == null) return Result<Unit>.Failure("");

            modifierGroup.Remove();

            await _modifierGroupRepository.UpdateAsync(modifierGroup);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
