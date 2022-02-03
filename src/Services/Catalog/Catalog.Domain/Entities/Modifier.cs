namespace Catalog.Domain.Entities
{
    public class Modifier
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Guid ModifierGroupId { get; private set; }

        public ModifierGroup ModifierGroup { get; private set; }
        public ICollection<ProductModifier> Products { get; private set; }

        public Modifier()
        {
            Id = Guid.NewGuid();
        }
    }
}
