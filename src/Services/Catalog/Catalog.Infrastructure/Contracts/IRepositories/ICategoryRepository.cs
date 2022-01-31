using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Contracts.IRepositories
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
