using System.Text.Json.Serialization;

namespace OnlineShop.WebApi.Angular.Models
{
    public class CategoryProduct
    {
        [JsonIgnore]
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
        [JsonIgnore]
        public Guid CategoryId { get; set; }
      
        public Category Category { get; set; }
    }
}
