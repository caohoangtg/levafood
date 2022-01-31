using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; private set; }

        public bool IsDeleted { get; private set; }
        public bool IsActivated { get; private set; }

        public string CreatedBy { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string LastModifiedBy { get; private set; }
        public DateTime? LastModifiedDate { get; private set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedBy = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
            LastModifiedBy = string.Empty;
        }

        public void UpdateCreated(string createdBy)
        {
            CreatedBy = createdBy;
            CreatedDate = DateTime.UtcNow;
        }

        public void UpdateLastModified(string lastModifiedBy)
        {
            LastModifiedBy = lastModifiedBy;
            LastModifiedDate = DateTime.UtcNow;
        }
    }
}
