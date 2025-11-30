
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IProductRepository
    {

        Task<Product> GetProductById(int userId,  int productId);

        Task<List<Product>> GetProducts(int userId);

        Task CreateProduct(int userId);

        Task DeleteProduct(int userId, int productId);

        Task UpdateProduct(int userId, int productId, Product product);

    }
}
