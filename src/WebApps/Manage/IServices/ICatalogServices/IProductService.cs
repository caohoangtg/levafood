using Manage.Models;

namespace Manage.IServices
{
    public interface IProductService
    {
        Task<ProductViewModel> CreateProduct(ProductViewModel model);
        Task<ProductViewModel> DeleteProduct(Guid id);
        Task<ProductViewModel> UpdateProduct(Guid id, ProductViewModel model);
        Task<IEnumerable<ProductViewModel>> GetProducts();
        Task<ProductViewModel> GetProduct(Guid id);
        Task<ProductViewModel> GetProductsPaged(string id);
    }
}
