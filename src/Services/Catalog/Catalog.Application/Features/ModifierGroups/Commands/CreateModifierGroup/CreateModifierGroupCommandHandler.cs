using AutoMapper;
using Catalog.Application.Models.Results;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;
namespace Catalog.Application.Features.ModifierGroups.Commands
{
    public class CreateModifierGroupCommandHandler : IRequestHandler<CreateModifierGroupCommand, Result<Unit>>
    {
        private readonly IModifierGroupRepository _modifierGroupRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateModifierGroupCommandHandler> _logger;

        public CreateModifierGroupCommandHandler(IModifierGroupRepository modifierGroupRepository, IMapper mapper, ILogger<CreateModifierGroupCommandHandler> logger)
        {
            _modifierGroupRepository = modifierGroupRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<Unit>> Handle(CreateModifierGroupCommand request, CancellationToken cancellationToken)
        {
            var modifierGroup = _mapper.Map<ModifierGroup>(request.ModifierGroup);

            if (modifierGroup == null) return Result<Unit>.Failure("Fails");

            //modifierGroup.UpdateForeignKey();
            
            await _modifierGroupRepository.AddAsync(modifierGroup);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
