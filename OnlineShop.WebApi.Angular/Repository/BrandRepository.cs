using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Brand>> GetListBrands()
        {
            return await _context.Brands.ToListAsync();
        }
        public async Task<Brand> GetBrandByName(string name)
        {
            return await _context.Brands
                    .Where(b => b.Name == name)
                    .FirstOrDefaultAsync();
        }

        public async Task<Brand> GetBrandById(Guid id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<Brand> GetBrand(Brand brand)
        {
            var result = await _context.Brands.FindAsync(brand);
            return result;
        }

        public async Task CreateBrand(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBrand(Brand brand)
        {
            var result = await GetBrandById(brand.Id);
            result.Name = brand.Name;
            result.Title = brand.Title;
            result.Description = brand.Description;
            result.ImgUrl = brand.ImgUrl;
            _context.Brands.Update(result);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveBrand(Brand brand)
        {
            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
        }
    }
}
