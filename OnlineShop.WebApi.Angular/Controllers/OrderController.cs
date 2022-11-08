using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;
using OnlineShop.WebApi.Angular.Models.DTOs;
using OnlineShop.WebApi.Angular.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<ActionResult> Create([FromBody] OrderRequestDto request)
        {
            if (request != null)
            {
                var user = await _userManager.FindByIdAsync(request.userId);
                if (user == null)
                    return BadRequest("User not exist");

                var cart = _cartServise.GetCartItems(request.cartId);
                if (cart == null)
                    return BadRequest("Cart is empty");

                await _order.CreateOrder(request);
                await _cartServise.ClearCart(request.cartId);
            }
            return BadRequest();
        }
    }
}
