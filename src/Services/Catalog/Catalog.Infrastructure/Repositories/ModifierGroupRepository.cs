using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contracts.IRepositories;
using Catalog.Infrastructure.Persistence;

namespace Catalog.Infrastructure.Repositories
{
    public class ModifierGroupRepository : RepositoryBase<ModifierGroup>, IModifierGroupRepository
    {
        public ModifierGroupRepository(CatalogContext dbContext) : base(dbContext)
        {

        }
    }
}
