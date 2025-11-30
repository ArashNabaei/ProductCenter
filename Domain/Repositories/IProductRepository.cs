
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {

        Task<Product> GetProductById(int userId,  int productId);

        Task<List<Product>> GetProducts(int userId);

        List<Product> GetProducts();

        Task<List<Product>> GetProductsFilteredByUser(int userId);

        Task CreateProduct(int userId, string name);

        Task DeleteProduct(int userId, int productId);

        Task UpdateProduct(int userId, int productId, Product product);

    }
}
