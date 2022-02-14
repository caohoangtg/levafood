namespace Manage.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public ICollection<VariantViewModel> Variants { get; set; }
        public ICollection<ProductModifierViewModel> Modifiers { get; set; }
        public ICollection<ProductModifierGroupViewModel> ModifierGroups { get; set; }
        public ICollection<PhotoViewModel> Photos { get; set; }
    }
}
