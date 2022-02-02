using System.ComponentModel.DataAnnotations;

namespace Catalog.Domain.Common
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }

        public bool IsDeleted { get; protected set; }
        public bool IsActivated { get; protected set; }

        [MaxLength(100)]
        public string CreatedBy { get; protected set; }
        public DateTime CreatedDate { get; protected set; }

        [MaxLength(100)]
        public string? LastModifiedBy { get; protected set; }
        public DateTime? LastModifiedDate { get; protected set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedBy = Guid.NewGuid().ToString();
            CreatedDate = DateTime.UtcNow;
            IsActivated = true;
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
