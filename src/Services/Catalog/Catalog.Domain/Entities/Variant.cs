namespace Catalog.Domain.Entities
{
    public class Variant
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public decimal Price { get; private set; }

        public Guid ProductId { get; private set; }

        public Product Product { get; private set; }

        public Variant()
        {
            Id = Guid.NewGuid();
        }
    }
}
