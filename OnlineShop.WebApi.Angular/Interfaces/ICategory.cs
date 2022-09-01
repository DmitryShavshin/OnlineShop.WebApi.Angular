using OnlineShop.WebApi.Angular.Models;


namespace OnlineShop.WebApi.Angular.Interfaces
{
    public interface ICategory
    {
        public Task CreateCategory(Category category);
        public Task<Category> GetCategory(Category category);
    }
}
