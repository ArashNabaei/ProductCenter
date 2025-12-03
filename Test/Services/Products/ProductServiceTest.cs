
using Application.Services.Products;
using Infrastructure.Repositories;
using Moq;

namespace Test.Services.Products
{
    public class ProductServiceTest
    {

        private readonly Mock<ProductRepository> _productRepository;

        private readonly IProductService _productService;

        public ProductServiceTest()
        {
            _productRepository = new Mock<ProductRepository>();
            _productService = new ProductService(_productRepository.Object,
                null);
        }

    }
}
