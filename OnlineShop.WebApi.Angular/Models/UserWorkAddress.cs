using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineShop.WebApi.Angular.Models
{
    public class UserWorkAddress
    {
        [Key]
        public Guid WorkAddressId { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public int? PostalCode { get; set; }

        [ForeignKey("ApplicationUser")]
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
