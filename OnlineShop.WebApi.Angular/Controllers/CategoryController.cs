using Microsoft.AspNetCore.Mvc;
using OnlineShop.WebApi.Angular.Interfaces;
using OnlineShop.WebApi.Angular.Models;


namespace OnlineShop.WebApi.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategory _category;

        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
            => Ok(await _category.GetListCategories());

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult Create() => Ok();

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> Create(Category category)
        {
            await _category.CreateCategory(category);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> Update(Category category)
        {
            if (ModelState.IsValid)
            {
                var result = await _category.GetCategoryById(category.Id);
                if (result != null)
                {
                    await _category.UpdateCategory(category);
                    return Ok("Category was updated");
                }
                else
                    return BadRequest("Category was not found");
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _category.GetCategoryById(id);
            if (result != null)
            {
                await _category.RemoveCategory(result);
                return Ok("Category was deleted");
            }
            else
                return BadRequest("Category not found");
        }
    }
}
