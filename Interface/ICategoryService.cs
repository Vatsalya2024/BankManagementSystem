using BOOKSTORE.Models.Entities;

namespace BOOKSTORE.Interface
{
    public interface ICategoryService
    {
        public Task<Category> AddCategory(Category category);
        public Task<bool> DeleteCategory(int id);
        public Task<Category> GetCategoryById(int id);
        public Task<List<Category>> GetAllCategory();
        public Task<Category> UpdateCategory(Category category);

    }
}
