namespace Catalog.Application.DTOs
{
    public class CategoryDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? MainCategoryId { get; set; }
    }
}
