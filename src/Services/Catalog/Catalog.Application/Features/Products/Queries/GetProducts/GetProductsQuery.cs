using Catalog.Application.Models.Results;
using Catalog.Application.ViewModels;
using MediatR;

namespace Catalog.Application.Features.Products.Queries
{
    public class GetProductsQuery : IRequest<Result<List<ProductViewModel>>>
    {
    }
}
