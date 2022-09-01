using OnlineShop.WebApi.Angular.Models;

namespace OnlineShop.WebApi.Angular.Interfaces
{
    public interface IBrand
    {
        public Task CreateBrand(Brand brand);
        public Task<Brand> GetBrand(Brand brand);
    }
}
