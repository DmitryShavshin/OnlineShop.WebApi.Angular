using System.Text.Json.Serialization;

namespace OnlineShop.WebApi.Angular.Models
{
    public class CategoryProduct
    {
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }

        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
