namespace Catalog.Domain.Entities
{
    public class Photo
    {
        public Guid Id { get; private set; } 
        public string Url { get; private set; } 

        public bool IsMain { get; private set; }

        public Guid ProductId { get; private set; }

        public Product Product { get; set; }

        public Photo()
        {
            Id = Guid.NewGuid();
        }
    }
}
