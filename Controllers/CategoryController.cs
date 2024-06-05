using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using BOOKSTORE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOKSTORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory([FromBody] Category category)
        {
            try
            {
                var addedcategory = await _categoryService.AddCategory(category);
                return addedcategory;
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> UpdateCategory(int id, [FromBody] Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest("Category ID mismatch");
            }

            try
            {
                var updatedCategory = await _categoryService.UpdateCategory(category);
                return Ok(updatedCategory);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            try
            {
                var deletedCategory = await _categoryService.DeleteCategory(id);
                return Ok(deletedCategory);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
