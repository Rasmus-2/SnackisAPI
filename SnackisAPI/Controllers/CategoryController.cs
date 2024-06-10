using Microsoft.AspNetCore.Mvc;
using SnackisAPI.Data;

namespace SnackisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryManager _categoryManager;
        public CategoryController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public async Task<List<Models.Category>> GetAllAsync()
        {
            var categories = await _categoryManager.GetCategories();
            return categories;
        }

        [HttpGet("{id}")]
        public async Task<Models.Category> GetOneAsync(int id)
        {
            var category = await _categoryManager.GetCategory(id);
            return category;
        }

        [HttpPost]
        public async Task PostOneAsync([FromBody] Models.Category category)
        {
            await _categoryManager.AddCategory(category);
        }

        [HttpPut("{id}")]
        public async Task UpdateOneAsync(int id, [FromBody] Models.Category category)
        {
            await _categoryManager.UpdateCategory(id, category);
        }


        [HttpDelete("{id}")]
        public async Task DeleteOneAsync(int id)
        {
            await _categoryManager.DeleteCategory(id);
        }
    }
}
