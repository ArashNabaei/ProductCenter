
using Application.Dtos;
using AutoMapper;
using Domain.Repositories;

namespace Application.Services.Products
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
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

        public async Task<List<ProductDto>> GetProducts(int userId)
        {
            var products = await _productRepository.GetProducts(userId);

            var productsDto =  _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public  List<ProductDto> GetProducts()
        {
            var products =  _productRepository.GetProducts();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public async Task CreateProduct(int userId, string name)
        {
            await _productRepository.CreateProduct(userId, name);
        }

        public Task DeleteProduct(int userId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(int userId, int productId, ProductDto productDto)
        {
            throw new NotImplementedException();
        }
    }
}
