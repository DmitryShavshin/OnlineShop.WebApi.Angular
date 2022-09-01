using OnlineShop.WebApi.Angular.Models;


namespace OnlineShop.WebApi.Angular.Interfaces
{
    public interface IProduct
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProductById(Guid id);
        public Task<Product> GetProductByName(string name);
        public Task CreateProduct(Product productRequest);
        public Task UpdateProduct(Product productRequest);
        public Task RemoveProduct(Product product);
        public Task Save();
    }
}
