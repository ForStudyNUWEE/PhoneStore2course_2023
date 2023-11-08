using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> FilterBy(string categoryName)
        {
            var products = await _context.Product.ToListAsync();
            List<Product> filteredProducts = new List<Product>();
            await _context.Category.ToListAsync();
            foreach (var product in products)
            {
                if (product.Category.Name == categoryName)
                {
                    filteredProducts.Add(product);
                }
            }

            return filteredProducts;
        }

        public async Task<List<Product>> SortBy()
        {
            var products = await _context.Product.ToListAsync();
            await _context.Category.ToListAsync();
            products.Sort();

            return products;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Product.ToListAsync();
            await _context.Category.ToListAsync();
            return products;
        }
        public async Task<Product> Get(int id)
        {
            var product = await _context.Product.FindAsync(id);
            return product;
        }
        public async Task Add(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task Edit(Product product)
        {
            _context.Product.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var product = await Get(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}