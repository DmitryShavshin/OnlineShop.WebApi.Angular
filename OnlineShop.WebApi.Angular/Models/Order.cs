using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebApi.Angular.Models
{
    public class Order
    {
        [Key]
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public double TotalPrice { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
