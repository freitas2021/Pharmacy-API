using Pharmacy.API.Models;

namespace Pharmacy.API.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();

        Task<Product?> GetProductById(long id);

        Task CreateProduct(Product product);

        Task UpdateProduct(long id, Product product);

        Task DeleteProduct(long id);
    }
}
