using OnlineShop.WebApi.Angular.Data;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;


namespace OnlineShop.WebApi.Angular.Repository
{
    public class BrandRepository : IBrand
    {
        private readonly ApplicationDbContext _context;
        public BrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateBrand(Brand brand)
        {
            var result = await GetBrand(brand);
            if (result != null)
            {
                await _context.Brands.AddAsync(brand);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Brand> GetBrand(Brand brand)
        {
            var result = await _context.Brands.FindAsync(brand);
            return result;
        }
    }
}
