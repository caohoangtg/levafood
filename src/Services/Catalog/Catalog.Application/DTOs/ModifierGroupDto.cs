namespace Catalog.Application.DTOs
{
    public class ModifierGroupDto
    {
        public string Name { get; set; }
        public ICollection<ModifierDto> Modifiers { get; set; }
    }
}
