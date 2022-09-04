using Microsoft.EntityFrameworkCore;
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
  
        public async Task<Category> GetCategoryById(Guid id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> GetCategoryByName(string name)
        {
            return await _context.Categories
                        .Where(c => c.Name == name)
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetListCategories()
        {
            return await _context.Categories.ToListAsync();
        }
        public async Task CreateCategory(Category category)
        {
            var result = GetCategoryByName(category.Name);
            if (result != null)
            {
                await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCategory(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            var result = await GetCategoryById(category.Id);
            result.Name = category.Name;
            result.Title = category.Title;
            result.Description = category.Description;
            result.ImgUrl = category.ImgUrl;
            _context.Categories.Update(result);
            await _context.SaveChangesAsync();
        }
    }
}
