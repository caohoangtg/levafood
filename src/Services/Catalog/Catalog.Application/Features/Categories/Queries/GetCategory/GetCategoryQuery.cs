using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Categories.Queries
{
    public class GetCategoryQuery : IRequest<Result<CategoryDto>>
    {
        public Guid Id { get; set; }
    }
}
