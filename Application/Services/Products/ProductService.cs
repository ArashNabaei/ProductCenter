
using Application.Dtos;
using Domain.Repositories;

namespace Application.Services.Products
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> GetProductById(int userId, int productId)
        {
            var product = await _productRepository.GetProductById(userId, productId);

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ProduceDate = product.ProduceDate,
                ManufacturePhone = product.ManufacturePhone,
                ManufactureEmail = product.ManufactureEmail,
                IsAvailable = product.IsAvailable,
            };

            return productDto;
        }

        public Task CreateProduct(int userId, string name)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProduct(int userId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProducts(int userId)
        {
            throw new NotImplementedException();
        }

        public List<ProductDto> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetProductsFilteredByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(int userId, int productId, ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
