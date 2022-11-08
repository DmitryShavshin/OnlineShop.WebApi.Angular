
using System.Text.Json.Serialization;

namespace OnlineShop.WebApi.Angular.Models
{
    public class CartItem
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string CartId { get; set; }
        [JsonIgnore]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
    }
}