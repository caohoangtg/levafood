using AutoMapper;
using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using Catalog.Application.Utilities;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace Catalog.Application.Features.ModifierGroups.Queries
{
    public class GetModifierGroupQueryHandler : IRequestHandler<GetModifierGroupQuery, Result<ModifierGroupDto>>
    {
        private readonly IModifierGroupRepository _modifierGroupRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetModifierGroupQueryHandler> _logger;

        public GetModifierGroupQueryHandler(IModifierGroupRepository modifierGroupRepository, IMapper mapper, ILogger<GetModifierGroupQueryHandler> logger)
        {
            _modifierGroupRepository = modifierGroupRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<ModifierGroupDto>> Handle(GetModifierGroupQuery request, CancellationToken cancellationToken)
        {
            List<Expression<Func<ModifierGroup, object>>> includes = new() { m => m.Modifiers, m => m.Products };
            Expression<Func<ModifierGroup, bool>> predicate = m => m.Name == "Topping" 
                && (m.Modifiers.Any() || m.Products.Any()) 
                && m.CreatedBy == "HoangTC";

            var modifierGroup = await _modifierGroupRepository.GetByIdAsync(request.Id, predicate, includes);

            if (modifierGroup == null) return Result<ModifierGroupDto>.Failure("Failure");

            return Result<ModifierGroupDto>.Success(_mapper.Map<ModifierGroupDto>(modifierGroup));
        }
    }
}
