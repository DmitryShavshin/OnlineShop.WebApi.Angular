using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebApi.Angular.Models.DTOs
{
    public class GetSingleOrderRequest
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public Guid OrderId { get; set; }
    }
}
