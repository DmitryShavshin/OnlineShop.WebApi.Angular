using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;
using OnlineShop.WebApi.Angular.Models.DTOs;

namespace OnlineShop.WebApi.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUser _user;

        public UserController(UserManager<ApplicationUser> userManager, IUser user)
        {
            _userManager = userManager;
            _user = user;
        }

        [HttpPost]
        [Route("UpdateUserContact")]
        public async Task<ActionResult> UpdateUserContact([FromBody]string userId)
        {
            return Ok();
        }

        //public async Task<ActionResult> UpdateUserContact(UserContactDto request)
        //{

        //}

        //public async Task<ActionResult> UpdateUserHomeAddress(UserHomeAddressDto request)
        //{

        //}

        //public async Task<ActionResult> UpdateUserWorkAddress(UserWorkAddressDto request)
        //{

        //}
    }
}
