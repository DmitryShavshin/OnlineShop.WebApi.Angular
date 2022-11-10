using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public Guid UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
