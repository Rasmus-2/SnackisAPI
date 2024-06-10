using Microsoft.EntityFrameworkCore;

namespace SnackisAPI.Data
{
    public class CategoryManager
    {
        private readonly MyDBContext _context;
        public CategoryManager(MyDBContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Category>> GetCategories()
        {
            List<Models.Category> categories = await _context.Category.ToListAsync();
            return categories;
        }

        public async Task<Models.Category> GetCategory(int id)
        {
            Models.Category category = await _context.Category.FindAsync(id);
            return category;
        }

        public async Task AddCategory(Models.Category category)
        {
            await _context.Category.AddAsync(category);

            //Behövs den? - Kolla sen
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(int id, Models.Category category)
        {
            Models.Category categoryExists = await _context.Category.FindAsync(id);
            if (categoryExists != null)
            {
                categoryExists.Name = category.Name;
                categoryExists.ParentId = category.ParentId;

                _context.Category.Update(categoryExists);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategory(int id)
        {
            Models.Category category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
