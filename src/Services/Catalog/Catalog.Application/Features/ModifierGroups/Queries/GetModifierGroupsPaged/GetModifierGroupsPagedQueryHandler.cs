using AutoMapper;
using AutoMapper.QueryableExtensions;
using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using Catalog.Infrastructure.Contracts.IRepositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Features.ModifierGroups.Queries.GetModifierGroupsPaged
{
    public class GetModifierGroupsPagedQueryHandler : IRequestHandler<GetModifierGroupsPagedQuery, Result<PagedList<ModifierGroupDto>>>
    {
        private readonly IModifierGroupRepository _modifierGroupRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetModifierGroupsPagedQueryHandler> _logger;

        public GetModifierGroupsPagedQueryHandler(IModifierGroupRepository modifierGroupRepository, IMapper mapper, ILogger<GetModifierGroupsPagedQueryHandler> logger)
        {
            _modifierGroupRepository = modifierGroupRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<PagedList<ModifierGroupDto>>> Handle(GetModifierGroupsPagedQuery request, CancellationToken cancellationToken)
        {
            var query = _modifierGroupRepository.GetAsQueryable()
                .ProjectTo<ModifierGroupDto>(_mapper.ConfigurationProvider);

            var modifierGroupsPaged = await PagedList<ModifierGroupDto>.CreateAsync(query, request.PagingParams.PageNumber, request.PagingParams.PageSize, request.PagingParams.Search);

            return Result<PagedList<ModifierGroupDto>>.Success(modifierGroupsPaged);
        }
    }
}
