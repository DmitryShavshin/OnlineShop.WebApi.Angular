using OnlineShop.WebApi.Angular.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.WebApi.Angular.Interfaces
{
    public interface IUser
    {
        public Task UpdateUserContact(UserContactDto request);
        public Task UpdateUserHomeAddress(UserHomeAddressDto request);
        public Task UpdateUserWorkAddress(UserWorkAddressDto request);
    }
}
