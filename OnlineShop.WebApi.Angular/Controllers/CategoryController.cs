using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;


namespace OnlineShop.WebApi.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly IBrand _brand;
        private readonly ICategory _category;

        public CategoryController(IProduct product, IBrand brand, ICategory category)
        {
            _product = product;
            _brand = brand;
            _category = category;
        }

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory() => Ok();

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await _category.CreateCategory(category);
            return Ok();
        }
    }
}
