using Manage.Extensions;
using Manage.IServices;
using Manage.Models;

namespace Manage.Services.CatalogServices
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private readonly string apiUrl = "api/Product";

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ProductViewModel> CreateProduct(ProductViewModel model)
        {
            var response = await _client.PostAsJson($"{apiUrl}/CreateProduct", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<ProductViewModel> DeleteProduct(Guid id)
        {
            var response = await _client.DeleteAsync($"{apiUrl}/DeleteProduct/{id}");
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var response = await _client.GetAsync($"{apiUrl}/GetProducts");
            return await response.ReadContentAs<List<ProductViewModel>>();
        }

        public async Task<ProductViewModel> GetProductsPaged(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductViewModel> GetProduct(Guid id)
        {
            var response = await _client.GetAsync($"{apiUrl}/GetProduct/{id}");
            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> UpdateProduct(Guid id, ProductViewModel model)
        {
            var response = await _client.PutAsJson($"{apiUrl}/UpdateProduct/{id}", model);
            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<ProductViewModel>();
            else
            {
                throw new Exception("Something went wrong when calling api.");
            }
        }
    }
}
