using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineShop.WebApi.Angular.Models
{
    public class OrderDetails
    {
        [Key]
        [JsonIgnore]
        public Guid OrderDetailId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
        [JsonIgnore]
        public Guid OrderId { get; set; }
        [JsonIgnore]
        public virtual Order Order { get; set; }

        [JsonIgnore]
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
