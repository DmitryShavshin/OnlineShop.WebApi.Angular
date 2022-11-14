using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;
using OnlineShop.WebApi.Angular.Models.DTOs;
using OnlineShop.WebApi.Angular.Services;

namespace OnlineShop.WebApi.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CartSevise _cartServise;
        private readonly IOrder _order;

        public OrderController(UserManager<ApplicationUser> userManager, CartSevise cartServise,
             IOrder order)
        {
            _userManager = userManager;
            _cartServise = cartServise;
            _order = order;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<ActionResult> Create([FromBody]OrderRequestDto request)
        {
            if (request != null)
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user == null)
                    return BadRequest("User not exist");

                var cart = await _cartServise.GetCartItems(request.CartId);
                if (cart == null || cart.Count == null)
                    return BadRequest("Cart is empty");

                await _order.CreateOrder(request, cart);
                await _cartServise.ClearCart(request.CartId);
                return Ok("Order created succesfuly");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("GetAllOrders/{id}")]
        public async Task<ActionResult<List<Order>>> GetAllOrders(string id)
        {
            if (id != null)
            {
                var user = await _userManager.FindByIdAsync(id.ToString());
                if (user == null)
                    return BadRequest("User not exist");

                var orders = await _order.GetOrders(id.ToString());
                if(orders != null)
                    return Ok(orders);

            }
            return BadRequest();
        }

        [HttpPost]
        [Route("GetSingleOrder")]
        public async Task<ActionResult<Order>> GetUserOrder([FromBody]GetSingleOrderRequest requestOrder)
        {
            if (requestOrder != null)
            {
                var user = await _userManager.FindByIdAsync(requestOrder.UserId);
                if (user == null)
                    return BadRequest("User not exist");

                var order = await _order.GetSingleOrder(requestOrder);
                if(order != null)
                    return Ok(order);
            }
            return BadRequest();
        }
    }
}
