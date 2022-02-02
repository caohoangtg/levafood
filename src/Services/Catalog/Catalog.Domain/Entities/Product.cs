using Catalog.Domain.Common;

namespace Catalog.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public Guid? CategoryId { get; private set; }
        public Category Category { get; private set; }

        public ICollection<Variant> Variants { get; private set; }
        public ICollection<ProductModifier> Modifiers { get; private set; }
        public ICollection<ProductModifierGroup> ModifierGroups { get; private set; }
        public ICollection<Photo> Photos { get; private set; }

        public void UpdateForeignKey()
        {
            if (ModifierGroups != null && !ModifierGroups.Any())
            {
                foreach (var modifierGroup in ModifierGroups)
                {
                    modifierGroup.UpdateProductId(Id);
                }

                if (Modifiers != null && !Modifiers.Any())
                {
                    foreach (var modifier in Modifiers)
                    {
                        modifier.UpdateProductId(Id);
                    }
                }
            }
        }
    }
}
