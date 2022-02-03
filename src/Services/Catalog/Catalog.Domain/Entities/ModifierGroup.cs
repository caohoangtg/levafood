using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class ModifierGroup : EntityBase
    {
        public string Name { get; private set; }
        public ICollection<ProductModifierGroup> Products { get; private set; }
        public ICollection<Modifier> Modifiers { get; private set; }

        public void Remove()
        {
            IsDeleted = true;
        }
    }
}
