
using Application.Dtos;

namespace Application.Services.Products
{
    public interface IProductService
    {

        Task<ProductDto> GetProductById(int userId, int productId);

        Task<List<ProductDto>> GetProducts(int userId);

        Task<List<ProductDto>> GetProducts();

        Task CreateProduct(int userId, string productName);

        Task DeleteProduct(int userId, int productId);

        Task UpdateProduct(int userId, int productId, ProductDto productDto);

    }
}
