using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }
}
