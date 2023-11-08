using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Get(int id)
        {
            var category = await _context.Category.FindAsync(id);
            return category;
        }
        public async Task Add(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task Edit(Category category)
        {
            _context.Category.Update(category);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var category = await Get(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}