using OnlineShop.WebApi.Angular.Models;
using OnlineShop.WebApi.Angular.Models.DTOs;

namespace OnlineShop.WebApi.Angular.Interfaces
{
    public interface IOrder
    {
        public Task CreateOrder(OrderRequestDto request, List<CartItem> cartItems);
        public Task<List<Order>> GetOrders(string requestId);
        public Task<Order> GetSingleOrder(GetSingleOrderRequest orderRequest);
    }
}
