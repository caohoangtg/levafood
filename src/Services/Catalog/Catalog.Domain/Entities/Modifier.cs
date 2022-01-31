using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Modifier : EntityBase
    {
        public string Name { get; private set; }
        public string Price { get; private set; }
        public string Tags { get; private set; }
        public Guid ModifierGroupId { get; private set; }

        public ICollection<Product> Products { get; private set; }
    }
}
