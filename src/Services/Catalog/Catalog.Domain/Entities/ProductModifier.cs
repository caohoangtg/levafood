namespace Catalog.Domain.Entities
{
    public class ProductModifier
    {
        public Guid ProductId { get; private set; }
        public Guid ModifierId { get; private set; }

        public Product Product { get; private set; }
        public Modifier Modifier { get; private set; }

        internal void UpdateProductId(Guid id)
        {
            ProductId = id;
        }
    }
}
