
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

            _mapper.Setup(m => m.Map<List<ProductDto>>(products))
                .Returns(prodcutDtos);

            var result = await _productService.GetProducts(userId);

            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(prodcutDtos.First().Id, result.First().Id);
            Assert.Equal(prodcutDtos.First().Name, result.First().Name);
        }

    }
}
