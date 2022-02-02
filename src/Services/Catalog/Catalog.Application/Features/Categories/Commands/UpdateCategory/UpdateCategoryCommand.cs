using Catalog.Application.DTOs;
using Catalog.Application.Models.Results;
using MediatR;
using System.Text.Json.Serialization;

namespace Catalog.Application.Features.Categories.Commands
{
    public class UpdateCategoryCommand : IRequest<Result<Unit>>
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public CategoryDto Category { get; set; }
    }
}
