using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OnlineShop.WebApi.Angular.Models
{
    public class UserContact
    {
        [Key]
        public Guid UserContactId { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Linkedin { get; set; }

        [ForeignKey("ApplicationUser")]
        [JsonIgnore]
        public Guid UserId { get; set; }
        [JsonIgnore]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
