namespace Catalog.Domain.Entities
{
    public class ProductModifierGroup
    {
        public Guid ProductId { get; private set; }
        public Guid ModifierGroupId { get; private set; }

        public Product Product { get; private set; }
        public ModifierGroup ModifierGroup { get; private set; }

        internal void UpdateProductId(Guid id)
        {
            ProductId = id;
        }
    }
}
