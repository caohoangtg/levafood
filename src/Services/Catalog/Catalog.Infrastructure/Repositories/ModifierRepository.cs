using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts.IRepositories;
using Catalog.Infrastructure.Persistence;

namespace Catalog.Infrastructure.Repositories
{
    public class ModifierRepository : RepositoryBase<Modifier>, IModifierRepository
    {
        public ModifierRepository(CatalogContext dbContext) : base(dbContext)
        {

        }
    }
}
