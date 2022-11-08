using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.Angular.Data;
using OnlineShop.WebApi.Angular.Models;
using System.Text;


namespace OnlineShop.WebApi.Angular.Services
{
    public class CartSevise
    {

        public string CartId { get; set; }
        public IEnumerable<CartItem> ListCartItems { get; set; }

        private readonly ApplicationDbContext _context;
        public CartSevise(ApplicationDbContext context)
        {
            _context = context;
        }

        public static CartSevise GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new CartSevise(context) { CartId = cartId };
        }

        public async Task AddToCart(Product product, string? requestCartId)
        {
            var cartItem = new CartItem();
            if (requestCartId == null)
            {
                cartItem = await _context.CartItems.SingleOrDefaultAsync(
                    s => s.Product.Id == product.Id && s.CartId == CartId);
            }
            else
            {
                cartItem = await _context.CartItems.SingleOrDefaultAsync(
                    s => s.Product.Id == product.Id && s.CartId == requestCartId);
            }
          
            if (cartItem == null)
            {
                await _context.CartItems.AddAsync(new CartItem
                {
                  
                    CartId = requestCartId == null ? CartId : requestCartId,
                    ProductId = product.Id,
                    Amount = 1
                });
            }
            else
            {
                cartItem.Amount++;
                _context.CartItems.Update(cartItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task Remove(Guid productId, string? requestCartId)
        {
            var cartItem = await _context.CartItems.SingleOrDefaultAsync(
                s => s.Product.Id == productId && s.CartId == requestCartId);         
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task ClearCart(string requestCartId)
        {
            var cartItems = await _context.CartItems
                .Where(i => i.CartId == requestCartId)
                .ToListAsync();
            if(cartItems != null)
                _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CartItem>> GetCartItems(string? requestCartId)
        {
            if (requestCartId == null)
            {
                return await _context.CartItems
                  .Where(c => c.CartId == CartId)
                  .Include(p => p.Product)
                  .ToListAsync();
            }
            return await _context.CartItems
                    .Where(c => c.CartId == requestCartId)
                    .Include(p => p.Product)
                    .ToListAsync();
        }

        public async Task MinusItem(Guid productId, string cartId)
        {

            var cartItem = await _context.CartItems
                .SingleOrDefaultAsync(i => i.ProductId == productId && i.CartId == cartId);
            if(cartItem != null && cartItem.Amount >= 1)
            {
                cartItem.Amount--;
                _context.CartItems.Update(cartItem);
            }
            if(cartItem != null && cartItem.Amount <= 0){
                _context.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
            
            await _context.SaveChangesAsync();
        }

        public  async Task<double> CartTotal(string requestCartId)
        {
            double total = _context.CartItems
             .Where(i => i.CartId == requestCartId)
             .Select(i => i.Product.Price * i.Amount).Sum();
            return total;
        }
    }
}
