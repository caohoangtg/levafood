using AutoMapper;
using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.ModifierGroups.Commands
{
    public class UpdateModifierGroupCommandHandler : IRequestHandler<UpdateModifierGroupCommand, Result<Unit>>
    {
        private readonly IModifierGroupRepository _modifierGroupRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateModifierGroupCommandHandler> _logger;

        public UpdateModifierGroupCommandHandler(IModifierGroupRepository modifierGroupRepository, IMapper mapper, ILogger<UpdateModifierGroupCommandHandler> logger)
        {
            _modifierGroupRepository = modifierGroupRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(UpdateModifierGroupCommand request, CancellationToken cancellationToken)
        {
            var modifierGroup = await _modifierGroupRepository.GetByIdAsync(request.Id);

            if (modifierGroup == null) return Result<Unit>.Failure("");

            _mapper.Map(request.ModifierGroup, modifierGroup);

            await _modifierGroupRepository.UpdateAsync(modifierGroup);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
