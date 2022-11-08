﻿using Microsoft.AspNetCore.Identity;


namespace OnlineShop.WebApi.Angular.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public virtual IEnumerable<Order> Orders { get; set; }
    }
}
