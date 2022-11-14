using Microsoft.EntityFrameworkCore;
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


        public async Task CreateOrder(OrderRequestDto request, List<CartItem> cartItems)
        {
            var order = new Order()
            {
                OrderId = Guid.NewGuid(),
                UserId = Guid.Parse(request.UserId),
                OrderDate = DateTime.Now,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                TotalPrice = request.TotalPrice
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();


            foreach (var item in cartItems)
            {
                var orderDetails = new OrderDetails()
                {
                    OrderId = order.OrderId,
                    ProductId = item.Product.Id,
                    UserId = Guid.Parse(request.UserId),
                    Price = item.Product.Price,
                    Amount = item.Amount
                };
                await _context.OrderDetails.AddAsync(orderDetails);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetOrders(string requestId)
        {
            List<Order> orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .Where(o => o.UserId == Guid.Parse(requestId))
                .ToListAsync();
            return orders;
        }

        public async Task<Order> GetSingleOrder(GetSingleOrderRequest orderRequest)
        {
            Order order = await _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.UserId == Guid.Parse(orderRequest.UserId) && o.OrderId == orderRequest.OrderId);
               
            return order;
        }
    }
}
