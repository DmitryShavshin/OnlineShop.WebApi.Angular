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
        public async Task<ActionResult<IEnumerable<Brand>>> Get()
           => Ok(await _brand.GetAllBrands());


        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult Create() => Ok();

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                var result = await _brand.GetBrandByName(brand.Name);
                if (result == null)
                {
                    await _brand.CreateBrand(brand);
                    return Ok("Brand was created");
                }
                else
                    return BadRequest("Brand allready exist");
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> Update(Guid id)
        {
            var result = await _brand.GetBrandById(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateBrand")]
        public async Task<IActionResult> Update(Brand response)
        {
            if (ModelState.IsValid) 
            {
                var result = await _brand.GetBrandById(response.Id);
                if (result != null)
                {
                    await _brand.UpdateBrand(response);
                    return Ok(result);
                }
                else
                    return BadRequest("Brand was not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _brand.GetBrandById(id);
            if (result != null)
            {
                await _brand.RemoveBrand(result);
                return Ok(result);
            }
            else
                return BadRequest("Brand not found");
        }
    }
}
