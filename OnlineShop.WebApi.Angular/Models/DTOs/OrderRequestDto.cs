using System.ComponentModel.DataAnnotations;

namespace OnlineShop.WebApi.Angular.Models.DTOs
{
    public class OrderRequestDto
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string CartId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public double TotalPrice { get; set; }
    }
}
