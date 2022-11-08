using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.Angular.Services;
using OnlineShop.WebApi.Angular.Models;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models.DTOs;

namespace OnlineShop.WebApi.Angular.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly CartSevise _cartServise;

        public CartController(IProduct product, CartSevise cartServise)
        {
            _product = product;
            _cartServise = cartServise;
        }

        [HttpGet]
        [Route("GetCart")]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }

        [HttpPost]
        [Route("GetProductsFromCart")]
        public async Task<ActionResult<List<CartItem>>> getProductsFromCart([FromBody]string? requestCartId)
        {
            var cartItems =  await _cartServise.GetCartItems(requestCartId);
            if (cartItems == null)
                return BadRequest("Cart is empty");
            else
                return Ok(cartItems);
        }


        [HttpPost]
        [Route("AddToCart")]
        public async Task<ActionResult<List<CartItem>>> AddToCart([FromBody]CartRequestDto cartRequest)
        {
            if (cartRequest != null)
            {
                var product = await _product.GetProductById(cartRequest.ProductId);
                if (product != null)
                    await _cartServise.AddToCart(product, cartRequest.CartId);

                var cartItems = await _cartServise.GetCartItems(cartRequest.CartId);
                if (cartItems == null)
                    return BadRequest("Cart is empty");
                else
                    return Ok(cartItems);
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("MinusCount")]
        public async Task<ActionResult<List<CartItem>>> MinusCount([FromBody]CartRequestDto cartRequest)
        {
            if (cartRequest != null)
            {
                await _cartServise.MinusItem(cartRequest.ProductId, cartRequest.CartId);
                var cartItems = await _cartServise.GetCartItems(cartRequest.CartId);
                if (cartItems == null)
                    return BadRequest("Cart is empty");
                else
                    return Ok(cartItems);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("RemoveProduct")]
        public async Task<ActionResult<List<CartItem>>>Remove([FromBody]CartRequestDto cartRequest)
        {
            if (cartRequest == null)
                return BadRequest();

            await _cartServise.Remove(cartRequest.ProductId, cartRequest.CartId);
            return await _cartServise.GetCartItems(cartRequest.CartId);
        }

        [HttpDelete]
        [Route("ClearCart/{id}")]
        public async Task<ActionResult> ClearCart(string id)
        {
            await _cartServise.ClearCart(id);
          
            return Ok();
        }
        //public async Task<ActionResult<List<CartItem>>> ClearCart(string id)
        //{
        //    await _cartServise.ClearCart(id);
        //    if (cartItems != null)
        //        return BadRequest();
        //    else
        //        return Ok(cartItems);
        //}
    }
}