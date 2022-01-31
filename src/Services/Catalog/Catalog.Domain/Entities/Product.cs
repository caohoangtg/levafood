using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public string Price { get; private set; }
        public string Description { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public Variant Variant { get; private set; }
        public ICollection<Modifier> Modifiers { get; private set; }
        public ICollection<Photo> Photos { get; private set; }
    }
}
