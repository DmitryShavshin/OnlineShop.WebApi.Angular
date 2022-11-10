using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop.WebApi.Angular.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public int Age { get; set; }
        public string Gender { get; set; } = "";
        [NotMapped]
        public IFormFile UserAvatar { get; set; }
        public virtual IEnumerable<Order> Orders { get; set; }
        public virtual UserHomeAddress HomeAddress { get; set; }
        public virtual UserWorkAddress WorkAddress { get; set; }
        public virtual UserContact UserContact { get; set; }
    }
}
