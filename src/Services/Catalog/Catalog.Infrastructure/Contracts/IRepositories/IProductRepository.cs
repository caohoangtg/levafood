using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Contracts.IRepositories
{
    public interface IProductRepository : IAsyncRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid category);
        IQueryable<Product> GetProductsAsQueryable();
    }
}
