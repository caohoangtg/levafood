using Catalog.Application.Models.Results;
using MediatR;

namespace Catalog.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<Result<Unit>>
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? MainCategoryId { get; set; }
    }
}
