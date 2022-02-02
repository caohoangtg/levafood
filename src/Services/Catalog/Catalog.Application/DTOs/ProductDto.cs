namespace Catalog.Application.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }

        public ICollection<VariantDto> Variants { get; set; }
        public ICollection<ProductModifierDto> Modifiers { get; set; }
        public ICollection<ProductModifierGroupDto> ModifierGroups { get; set; }
        public ICollection<PhotoDto> Photos { get; set; }
    }
}
