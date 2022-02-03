using AutoMapper;
using Catalog.Application.Models.Results;
using Catalog.Application.ViewModels;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Catalog.Application.Features.ModifierGroups.Queries
{
    public class GetModifierGroupsQueryHandler : IRequestHandler<GetModifierGroupsQuery, Result<List<ModifierGroupViewModel>>>
    {
        private readonly IModifierGroupRepository _modifierGroupRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetModifierGroupsQueryHandler> _logger;

        public GetModifierGroupsQueryHandler(IModifierGroupRepository modifierGroupRepository, IMapper mapper, ILogger<GetModifierGroupsQueryHandler> logger)
        {
            _modifierGroupRepository = modifierGroupRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<List<ModifierGroupViewModel>>> Handle(GetModifierGroupsQuery request, CancellationToken cancellationToken)
        {
            var modifierGroups = await _modifierGroupRepository.GetAllAsync();

            return Result<List<ModifierGroupViewModel>>.Success(_mapper.Map<List<ModifierGroupViewModel>>(modifierGroups));
        }
    }
}
