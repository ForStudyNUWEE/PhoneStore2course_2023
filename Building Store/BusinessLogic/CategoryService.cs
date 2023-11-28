using Core.Entities;
using Core.Interfaces;

namespace Core
{
    internal class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepo;
        public CategoryService(IRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public async Task<Category> Get(int id)
        {
            var category = await _categoryRepo.GetByID(id);
            return category;
        }
        public async Task Add(Category category)
        {
            await _categoryRepo.Insert(category);
            await _categoryRepo.Save();
        }
        public async Task Edit(Category category)
        {
            await _categoryRepo.Update(category);
            await _categoryRepo.Save();
        }
        public async Task Delete(int id)
        {
            var category = await Get(id);
            await _categoryRepo.Delete(category);
            await _categoryRepo.Save();
        }
    }
}