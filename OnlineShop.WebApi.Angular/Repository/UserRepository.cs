using OnlineShop.WebApi.Angular.Data;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models.DTOs;

namespace OnlineShop.WebApi.Angular.Repository
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task UpdateUserContact(UserContactDto request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserHomeAddress(UserHomeAddressDto request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserWorkAddress(UserWorkAddressDto request)
        {
            throw new NotImplementedException();
        }
    }
}
