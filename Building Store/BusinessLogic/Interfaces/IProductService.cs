using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> FilterBy(string categoryName);

        public Task<List<Product>> SortBy();

        public Task<List<Product>> GetAll();
        public Task<Product> Get(int id);
        public Task Add(Product product);
        public Task Edit(Product product);
        public Task Delete(int id);
    }
}
