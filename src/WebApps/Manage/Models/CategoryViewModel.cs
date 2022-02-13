namespace Manage.Models
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public Guid? MainCategoryId { get; set; }
    }
}
