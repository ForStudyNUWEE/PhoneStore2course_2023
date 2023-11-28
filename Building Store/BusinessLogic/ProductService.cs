using Core.Entities;
using Core.Interfaces;

namespace Core
{
    internal class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Category> _categoryRepo;
        public ProductService(IRepository<Product> productRepo,
                              IRepository<Category> categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<List<Product>> FilterBy(string categoryName)
        {
            var products = await _productRepo.GetAll();
            List<Product> filteredProducts = new List<Product>();
            await _categoryRepo.GetAll();
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
            var products = await _productRepo.GetAll();
            await _categoryRepo.GetAll();
            products.Sort();

            return products;
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _productRepo.GetAll();
            await _categoryRepo.GetAll();
            return products;
        }
        public async Task<Product> Get(int id)
        {
            var product = await _productRepo.GetByID(id);
            return product;
        }
        public async Task Add(Product product)
        {
            await _productRepo.Insert(product);
            await _productRepo.Save();
        }
        public async Task Edit(Product product)
        {
            await _productRepo.Update(product);
            await _productRepo.Save();
        }
        public async Task Delete(int id)
        {
            var product = await Get(id);
            await _productRepo.Delete(product);
            await _productRepo.Save();
        }
    }
}