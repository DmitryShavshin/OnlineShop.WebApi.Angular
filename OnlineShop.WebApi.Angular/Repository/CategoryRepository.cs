using OnlineShop.WebApi.Angular.Data;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;

namespace OnlineShop.WebApi.Angular.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateCategory(Category category)
        {
            var result = GetCategory(category);
            if (result != null)
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Category> GetCategory(Category category)
        {
            var result = await _context.Categories.FindAsync(category);
            return result;
        }
    }
}
