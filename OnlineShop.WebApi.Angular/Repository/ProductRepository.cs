using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.Angular.Data;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;

namespace OnlineShop.WebApi.Angular.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            IEnumerable<Product> products = await _context.Products
                                .Include(b => b.Brand)
                                .Include(cp => cp.CategoryProducts)
                                .ThenInclude(c => c.Category)
                                .ToListAsync();
            return products;
        }
        public async Task<Product> GetProductById(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            return product;
        }

        public async Task<Product> GetProductByName(string name)
        {
            var product = await _context.Products
                .Where(p => p.Name == name)
                .FirstOrDefaultAsync();
            return product;
        }

        public async Task CreateProduct(Product productRequest)
        {
            await _context.Products.AddAsync(productRequest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product productRequest)
        {
            var product = await GetProductByName(productRequest.Name);
            product.Name = productRequest.Name;
            product.Title = productRequest.Title;
            product.Price = productRequest.Price;
            product.Description = productRequest.Description;
            product.ImgUrl = productRequest.ImgUrl;

            _context.Products.Update(product);
            await Save();
        }

        public async Task RemoveProduct(Product product)
        {
            _context.Products.Remove(product);
            await Save();
        }

        public async Task Save()
        {
           await _context.SaveChangesAsync();
        }
    }
}
