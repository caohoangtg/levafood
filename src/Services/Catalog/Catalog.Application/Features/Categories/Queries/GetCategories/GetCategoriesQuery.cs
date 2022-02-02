using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<Result<List<CategoryDto>>>
    {
    }
}
