using OnlineShop.WebApi.Angular.Models;


namespace OnlineShop.WebApi.Angular.Interfaces
{
    public interface ICategory
    {
        public Task<IEnumerable<Category>> GetListCategories();
        public Task<Category> GetCategoryById(Guid id);
        public Task<Category> GetCategoryByName(string name);
        public Task CreateCategory(Category category);
        public Task UpdateCategory(Category category);
        public Task RemoveCategory(Category category);
    }
}
