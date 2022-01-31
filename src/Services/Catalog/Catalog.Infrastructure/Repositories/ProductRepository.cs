using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts.IRepositories;
using Catalog.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(CatalogContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid category)
        {
            return await _dbContext.Products
                .Where(p => p.CategoryId == category)
                .ToListAsync();
        }

        public IQueryable<Product> GetProductsAsQueryable()
        {
            return _dbContext.Products.AsQueryable();
        }
    }
}
