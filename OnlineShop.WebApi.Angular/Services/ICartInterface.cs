using OnlineShop.WebApi.Angular.Models;


namespace OnlineShop.WebApi.Angular.Services
{
    public interface ICartInterface
    {
        public Task AddToCart(Product prduct);
        public Task Remove(Product product);
        public void ClearCart();
        public double CartTotal();
        public IEnumerable<CartItem> GetCartItems();
    }
}