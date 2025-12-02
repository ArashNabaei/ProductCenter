
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly EfContext _efcontext;

        public ProductRepository(EfContext efContext)
        {
            _efcontext = efContext;
        }

        public async Task<Product> GetProductById(int userId, int ProductId)
        {
            var product = await _efcontext.Products.FirstOrDefaultAsync(p => p.Id == ProductId && p.User.Id == userId);

            if (product == null)
                throw new Exception("There is no product with this information.");

            return product;
        }

        public async Task<List<Product>> GetProducts(int userId)
        {
            var products = await _efcontext.Products.AsNoTracking().Where(p => p.User.Id == userId).ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProducts()
        {
            var products = await  _efcontext.Products.AsNoTracking().ToListAsync();

            return products;
        }

        public async Task CreateProduct(int userId, string name)
        {
            var product = new Product
            {
               Name = name,
               ProduceDate = DateTime.UtcNow,
               UserId = userId,
            };

            await _efcontext.Products.AddAsync(product);
            await _efcontext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int userId, int productId)
        {
            var product = await _efcontext.Products.FirstOrDefaultAsync(p => p.Id == productId && p.User.Id == userId);

            if (product == null)
                throw new Exception("There is no product with this information.");

            _efcontext.Remove(product);

            await _efcontext.SaveChangesAsync();
        }

        public async Task UpdateProduct(int userId, int productId, Product product)
        {
            var existingProduct = await _efcontext.Products.FirstOrDefaultAsync(p => p.User.Id == userId && p.Id == productId);

            if (existingProduct == null)
                throw new Exception("There is no product with this information.");

            existingProduct.Name = product.Name;
            existingProduct.ManufacturePhone = product.ManufacturePhone;
            existingProduct.ManufactureEmail = product.ManufactureEmail;
            existingProduct.IsAvailable = product.IsAvailable;
            existingProduct.ProduceDate = product.ProduceDate;

            await _efcontext.SaveChangesAsync();
        }
    }
}
