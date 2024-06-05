using BOOKSTORE.Data;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Repository
{
    public class CategoryRepository : IRepository<int, Category>
    {
        private readonly BookStoreDBContext _bookStoreDBContext;

        public CategoryRepository(BookStoreDBContext bookStoreDBContext)
        {
            _bookStoreDBContext = bookStoreDBContext;
        }

        public async Task<Category> Add(Category item)
        {
            var category = _bookStoreDBContext.Categories.FirstOrDefault(c => c.Name == item.Name);
            if (category != null)
            {
                throw new ApplicationException();
            }
            _bookStoreDBContext.Categories.Add(item);
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }

        public async Task<Category?> Delete(int key)
        {
            var category = await Get(key);
            if (category == null)
            {
                throw new ApplicationException("Category not found.");
            }
            else
            {
                _bookStoreDBContext.Categories.Remove(category);
                await _bookStoreDBContext.SaveChangesAsync();
                return category;
            }

            throw new NotImplementedException();
        }

        public async Task<Category?> Get(int key)
        {
            var getCategories = await GetAll();
            var getCategory = getCategories.FirstOrDefault(g => g.CategoryId == key);
            if (getCategory != null)
            {
                return getCategory;
            }
            return null;

            //throw new CategoryNotFoundException();
        }

        public Task<List<Category>?>? GetAll()
        {
            var getCategories = _bookStoreDBContext.Categories.Include(a => a.BookCategories).ToListAsync();
            if (getCategories == null)
            {
                return null;
            }
            return getCategories;
        }

        public async Task<Category> Update(Category item)
        {
            _bookStoreDBContext.Entry<Category>(item).State = EntityState.Modified;
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }
    }
}