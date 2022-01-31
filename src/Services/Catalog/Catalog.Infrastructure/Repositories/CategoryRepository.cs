using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts.IRepositories;
using Catalog.Infrastructure.Persistence;

namespace Catalog.Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(CatalogContext dbContext) : base(dbContext)
        {

        }
    }
}
