
using Application.Dtos;

namespace Application.Services.Products
{
    public interface IProductService
    {

        Task<ProductDto> GetProductById(int userId, int productId);

        Task<List<ProductDto>> GetProducts(int userId);

        List<ProductDto> GetProducts();

        Task<List<ProductDto>> GetProductsFilteredByUser(int userId);

        Task CreateProduct(int userId, string name);

        Task DeleteProduct(int userId, int productId);

        Task UpdateProduct(int userId, int productId, ProductDto productDto);

    }
}
