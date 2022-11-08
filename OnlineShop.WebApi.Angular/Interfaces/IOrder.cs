using OnlineShop.WebApi.Angular.Models.DTOs;

namespace OnlineShop.WebApi.Angular.Interfaces
{
    public interface IOrder
    {
        public Task CreateOrder(OrderRequestDto request);
    }
}
