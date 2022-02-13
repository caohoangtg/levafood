using Manage.Models;

namespace Manage.IServices
{
    public interface ICategoryService
    {
        Task<CategoryViewModel> CreateCategory(CategoryViewModel model);
        Task<CategoryViewModel> DeleteCategory(Guid id);
        Task<CategoryViewModel> UpdateCategory(Guid id, CategoryViewModel model);
        Task<IEnumerable<CategoryViewModel>> GetCategories();
        Task<CategoryViewModel> GetCategory(Guid id);
        Task<CategoryViewModel> GetCategoriesPaged(string id);
    }
}
