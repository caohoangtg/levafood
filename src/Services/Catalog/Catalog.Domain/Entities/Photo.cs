using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Photo : EntityBase
    {
        public string Url { get; private set; }

        public bool IsMain { get; private set; }

        public Guid ProductId { get; private set; }

        public Product Product { get; set; }
    }
}
