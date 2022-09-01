using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.Angular.Data;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;


namespace OnlineShop.WebApi.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly IBrand _brand;
        private readonly ICategory _category;

        public BrandController(IProduct product, IBrand brand, ICategory category)
        {
            _product = product;
            _brand = brand;
            _category = category;
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand() => Ok();

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(Brand brand)
        {
            await _brand.CreateBrand(brand);
            return Ok();
        }
    }
}
