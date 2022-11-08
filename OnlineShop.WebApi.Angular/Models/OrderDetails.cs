using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebApi.Angular.Models
{
    public class OrderDetails
    {
        [Key]
        public Guid OrderDetailId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        

        public Guid UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        
        public Guid OrderId { get; set; }
        public virtual Order Order { get; set; }


        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
