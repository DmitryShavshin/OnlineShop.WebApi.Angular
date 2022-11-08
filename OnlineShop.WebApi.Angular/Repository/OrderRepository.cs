using OnlineShop.WebApi.Angular.Data;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;
using OnlineShop.WebApi.Angular.Models.DTOs;
using OnlineShop.WebApi.Angular.Services;

namespace OnlineShop.WebApi.Angular.Repository
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationDbContext _context;
        private readonly CartSevise _cartServise;
        public OrderRepository(CartSevise cartSevise, ApplicationDbContext context)
        {
            _cartServise = cartSevise;
            _context = context;
        }


        public async Task CreateOrder(OrderRequestDto request)
        {
            var cart = await _cartServise.GetCartItems(request.cartId);

            var order = new Order()
            {
                OrderId = Guid.NewGuid(),
                UserId = Guid.Parse(request.userId),
                OrderDate = DateTime.Now,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                TotalPrice = await _cartServise.CartTotal(request.cartId)
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();


            foreach (var item in cart)
            {
                var orderDetails = new OrderDetails()
                {
                    OrderId = order.OrderId,
                    ProductId = item.Product.Id,
                    UserId = Guid.Parse(request.userId),
                    Price = item.Product.Price,
                    Amount = item.Amount
                };
                await _context.OrderDetails.AddAsync(orderDetails);
            }
            await _context.SaveChangesAsync();
        }
    }
}
