using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Category : EntityBase
    {
        public string Name { get; private set; }
        public string Image { get; private set; }
        public Guid? MainCategoryId { get; private set; }

        public ICollection<Product> Products { get; private set; }

        public void Remove()
        {
            IsDeleted = true;
        }
    }
}
