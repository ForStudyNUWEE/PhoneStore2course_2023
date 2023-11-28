using Core.Entities;
using Core.Interfaces;

namespace Core
{
    public interface ICategoryService
    {
        public Task<Category> Get(int id);
        public Task Add(Category category);
        public Task Edit(Category category);
        public Task Delete(int id);
    }
}