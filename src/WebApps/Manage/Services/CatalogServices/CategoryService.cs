using Manage.Extensions;
using Manage.IServices;
using Manage.Models;

namespace Manage.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _client;
        private readonly string apiUrl = "api/Category";

        public CategoryService(HttpClient client)
        {
            _client = client;
        }

        public async Task<CategoryViewModel> CreateCategory(CategoryViewModel model)
        {
            var response = await _client.PostAsJson($"{apiUrl}/CreateCategory", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CategoryViewModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<CategoryViewModel> DeleteCategory(Guid id)
        {
            var response = await _client.DeleteAsync($"{apiUrl}/DeleteCategory/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CategoryViewModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var response = await _client.GetAsync($"{apiUrl}/GetCategories");
            return await response.ReadContentAs<List<CategoryViewModel>>();
        }

        public async Task<CategoryViewModel> GetCategoriesPaged(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryViewModel> GetCategory(Guid id)
        {
            var response = await _client.GetAsync($"{apiUrl}/GetCategory/{id}");
            return await response.ReadContentAs<CategoryViewModel>();
        }

        public async Task<CategoryViewModel> UpdateCategory(Guid id, CategoryViewModel model)
        {
            var response = await _client.PutAsJson($"{apiUrl}/UpdateCategory/{id}", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<CategoryViewModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
