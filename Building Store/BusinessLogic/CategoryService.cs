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
        public Category Get(int id)
        {
            var category = _context.Category.Find(id);
            return category;
        }
        public void Add(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
        }
        public void Edit(Category category)
        {
            _context.Category.Update(category);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var category = Get(id);
            _context.Category.Remove(category);
            _context.SaveChanges();
        }
    }
}