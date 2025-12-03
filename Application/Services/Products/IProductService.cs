
using Application.Dtos;

namespace Application.Services.Products
{
    public interface IProductService
    {

        Task<ProductDto> GetProductById(int userId, int productId);

        Task<IEnumerable<ProductDto>> GetProducts(int userId);

        Task<IEnumerable<ProductDto>> GetProducts();

        Task CreateProduct(int userId, string productName);

        Task DeleteProduct(int userId, int productId);

        Task UpdateProduct(int userId, int productId, ProductDto productDto);

    }
}
