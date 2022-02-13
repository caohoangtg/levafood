using Catalog.Application.Models.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Catalog.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<Result<Unit>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? MainCategoryId { get; set; }
    }
}
