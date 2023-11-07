using DataAccess;
using DataAccess.Entities;

namespace BusinessLogic
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> FilterBy(string categoryName)
        {
            var products = _context.Product.ToList();
            List<Product> filteredProducts = new List<Product>();
            _context.Category.ToList();
            foreach (var product in products)
            {
                if (product.Category.Name == categoryName)
                {
                    filteredProducts.Add(product);
                }    
            }

            return filteredProducts;
        }

        public List<Product> SortBy()
        {
            var products = _context.Product.ToList();
            _context.Category.ToList();
            products.Sort();

            return products;
        }

        public List<Product> GetAll()
        {
            var products = _context.Product.ToList();
            _context.Category.ToList();
            return products;
        }
        public Product Get(int id)
        {
            var product = _context.Product.Find(id);
            return product;
        }
        public void Add(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
        }
        public void Edit(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = Get(id);
            _context.Product.Remove(product);
            _context.SaveChanges();
        }
    }
}