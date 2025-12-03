
using Application.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Shared.Exceptions.Products;

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

            if (product == null)
                throw ProductException.ProductNotFound();

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

        public async Task<IEnumerable<ProductDto>> GetProducts(int userId)
        {
            var products = await _productRepository.GetProducts(userId);

            if (products == null)
                throw ProductException.NoProductsFound();

            var productsDto =  _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            if (products == null)
                throw ProductException.NoProductsFound();

            var productsDto = _mapper.Map<List<ProductDto>>(products);

            return productsDto;
        }

        public async Task CreateProduct(int userId, string name)
        {
            await _productRepository.CreateProduct(userId, name);
        }

        public async Task DeleteProduct(int userId, int productId)
        {
            var existingProduct = await _productRepository.GetProductById(userId, productId);
            
            if (existingProduct == null)
                throw ProductException.ProductNotFound();

            await _productRepository.DeleteProduct(userId, productId);
        }

        public async Task UpdateProduct(int userId, int productId, ProductDto productDto)
        {
            var existingProduct = await _productRepository.GetProductById(userId, productId);
            
            if (existingProduct == null)
                throw ProductException.ProductNotFound();

            _mapper.Map(productDto, existingProduct);

            await _productRepository.UpdateProduct(userId, productId, existingProduct);
        }

    }
}
