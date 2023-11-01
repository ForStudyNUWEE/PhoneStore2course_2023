using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic
{
    public class HomeService
    {
        private readonly ApplicationDbContext _context;
        public HomeService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Category> ChangeName()
        {
            var products = _context.Product.ToList();
            var categories = _context.Category.ToList();
            if (products[0].Name == "IPhone 7")
            {
                products[0].Name = "IPhone";
            }
            return categories;
        }
        //public void Add(Category category)
        //{
        //    _context.Add(category);
        //    _context.SaveChanges();
        //}
        public Product Get(int id)
        {
            var product = _context.Product.Find(id);
            return product;
        }
        //public Category GetCategory(int id)
        //{
        //    var category = _context.Category.Find(id);
        //    return category;
        //}
        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(int id)
        {
            var product = Get(id);
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
        public void EditProduct(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
        }
    }
}