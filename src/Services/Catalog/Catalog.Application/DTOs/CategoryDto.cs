namespace Catalog.Application.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? MainCategoryId { get; set; }
    }
}
