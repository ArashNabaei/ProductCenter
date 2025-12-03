
using Application.Dtos;
using Application.Services.Products;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Moq;
using Shared.Exceptions.Products;
using Test.Mocks;

namespace Test.Services.Products
{
    public class ProductServiceTest
    {

        private readonly Mock<IProductRepository> _productRepository;

        private readonly IProductService _productService;

        private readonly Mock<IMapper> _mapper;

        public ProductServiceTest()
        {
            _productRepository = new Mock<IProductRepository>();
            _mapper = new Mock<IMapper>();

            _productService = new ProductService(_productRepository.Object,
                _mapper.Object);
        }

        [Fact]
        public async Task GetProductById_WhenProductExists_ShouldReturnProduct()
        {
            int userId = 1;
            int productId = 10;

            var product = ProductMocks.ValidProduct();

            _productRepository.Setup(r => r.GetProductById(userId, productId))
                .ReturnsAsync(product);

            var result = await _productService.GetProductById(userId, productId);

            Assert.NotNull(result);
            Assert.Equal(product.Id, result.Id);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.ManufacturePhone, result.ManufacturePhone);
            Assert.Equal(product.ManufactureEmail, result.ManufactureEmail);
            Assert.Equal(product.IsAvailable, result.IsAvailable);
        }

        [Fact]
        public async Task GetProductById_WhenNotFound_ShouldThrowProductNotFoundException()
        {
            int userId = 1;
            int productId = 5;

            _productRepository.Setup(r => r.GetProductById(userId, productId))
                .ReturnsAsync((Product?)null);

            var exception = await Assert.ThrowsAsync<ProductException>(
                () => _productService.GetProductById(userId, productId)
            );

            Assert.Equal(2001, exception.Code);
        }

        [Fact]
        public async Task GetProducts_ByUser_WhenProductsExist_ShouldReturnProducts()
        {
            int userId = 1;

            var products = ProductMocks.Products();

            var prodcutDtos = ProductMocks.ProductDtos();

            _productRepository.Setup(r => r.GetProducts(userId))
                .ReturnsAsync(products);

            _mapper.Setup(m => m.Map<IEnumerable<ProductDto>>(products))
                .Returns(prodcutDtos);

            var result = await _productService.GetProducts(userId);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(prodcutDtos.First().Id, result.First().Id);
            Assert.Equal(prodcutDtos.First().Name, result.First().Name);
        }

        [Fact]
        public async Task GetProducts_ByUser_WhenNoneFound_ShouldThrowNoProductsFoundException()
        {
            int userId = 1;

            _productRepository.Setup(r => r.GetProducts(userId))
                .ReturnsAsync((List<Product>?)null);

            var exception = await Assert.ThrowsAsync<ProductException>(
                () => _productService.GetProducts(userId)
            );

            Assert.Equal(2003, exception.Code);
        }

        [Fact]
        public async Task GetProducts_WhenProductsExist_ShouldReturnProductDtos()
        {
            var products = ProductMocks.Products();

            var productDtos = ProductMocks.ProductDtos();

            _productRepository.Setup(r => r.GetProducts())
                .ReturnsAsync(products);

            _mapper.Setup(m => m.Map<IEnumerable<ProductDto>>(products))
                .Returns(productDtos);

            var result = await _productService.GetProducts();

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(1, result.First().Id);
            Assert.Equal("Product", result.First().Name);
        }

        [Fact]
        public async Task GetProducts_WhenNoneFound_ShouldThrowNoProductsFoundException()
        {
            _productRepository.Setup(r => r.GetProducts())
                .ReturnsAsync((List<Product>?)null);

            var exception = await Assert.ThrowsAsync<ProductException>(
                () => _productService.GetProducts()
            );

            Assert.Equal(2003, exception.Code);
        }

    }
}
