using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Variant : EntityBase
    {
        public string Name { get; private set; }

        public string Price { get; private set; }

        //[ForeignKey("Product")]
        public Guid ProductId { get; private set; }

        public Product Product { get; private set; }
    }
}
