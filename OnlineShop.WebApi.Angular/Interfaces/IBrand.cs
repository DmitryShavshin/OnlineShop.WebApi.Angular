using OnlineShop.WebApi.Angular.Models;

namespace OnlineShop.WebApi.Angular.Interfaces
{
    public interface IBrand
    {
        public Task<IEnumerable<Brand>> GetListBrands();  
        public Task<Brand> GetBrandByName(string name);
        public Task<Brand> GetBrandById(Guid id);
        public Task CreateBrand(Brand brand);
        public Task UpdateBrand(Brand brand);
        public Task RemoveBrand(Brand brand);
    }
}
