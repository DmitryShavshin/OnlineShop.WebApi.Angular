using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.WebApi.Angular.Models
{
    public class UserHomeAddress
    {

        [Key]
        public Guid HomeAddressId { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public int? PostalCode { get; set; }

        [ForeignKey("ApplicationUser")]
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
