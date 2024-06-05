using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.VisualBasic;

namespace BOOKSTORE.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<int,Category> _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IRepository<int, Category> categoryRepository, ILogger<CategoryService> logger)
        {
            _categoryRepository=categoryRepository;
            _logger=logger;
        }
        public async Task<Category> AddCategory(Category category)
        {
            return await _categoryRepository.Add(category);
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category=await _categoryRepository.Get(id);
            if (category!=null)
            {
                await _categoryRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var categories = await _categoryRepository.GetAll();
            var category=categories.FirstOrDefault(e=>e.CategoryId==id);
            if(category!=null)

            {
                return category;            
            }
            throw new NoSuchCategoryException();


        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var bookCategory= await _categoryRepository.Get(category.CategoryId);
            if(bookCategory!=null)
            {
                bookCategory.Name=category.Name;
                bookCategory.Description=category.Description;
                bookCategory=await _categoryRepository.Update(bookCategory);
                return bookCategory;
            }
            throw new NoSuchCategoryException();
        }
    }
}
