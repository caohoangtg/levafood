using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Result<Unit>>
    {
        public CategoryDto Category { get; set; }
    }
}
