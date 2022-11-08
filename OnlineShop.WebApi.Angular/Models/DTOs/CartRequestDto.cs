

namespace OnlineShop.WebApi.Angular.Models.DTOs
{
    public class CartRequestDto
    {
        public Guid ProductId { get; set; }
        public string? CartId { get; set; }
    }
}