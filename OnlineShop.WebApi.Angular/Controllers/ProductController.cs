using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop.WebApi.Angular.Data;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;


namespace OnlineShop.WebApi.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;
        private readonly IBrand _brand;
        private readonly ICategory _category;
        private readonly ApplicationDbContext _context;

        public ProductController(IProduct product, IBrand brand, ICategory category, ApplicationDbContext context)
        {
            _product = product;
            _brand = brand;
            _category = category;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
            => Ok(await _product.GetListProducts());
        

        [HttpGet]
        [Route("CreateProduct")]
        public IActionResult CreateProduct() => Ok();

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<ActionResult<IEnumerable<Product>>> CreateProduct(Product product)
        {
            var existingProduct = await _product.GetProductByName(product.Name);

            if (existingProduct != null)
                return BadRequest("Product allready exist");

            await _product.CreateProduct(product);
            return Ok(await _product.GetListProducts());
        }

        [HttpGet]
        [Route("GetProduct")]
        public IActionResult GetProduct() => Ok();

        [HttpPost]
        [Route("GetProduct/{id}")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _product.GetProductById(id);
            if (product == null)
                return BadRequest("Product not found");

            return Ok(product);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product productRequest)
        {
            if (ModelState.IsValid)
            {
                var product = await _product.GetProductById(productRequest.Id);
                if (product != null)
                {       
                    await _product.UpdateProduct(productRequest);
                    return Ok(product);
                }else
                    return BadRequest("Product not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var product = await _product.GetProductById(id);
            if (product != null)
            {
                await _product.RemoveProduct(product);
                return Ok("Product was removed suxessfully");
            }
            else
                return BadRequest("Product not found");
        }
    }
}
