using BOOKSTORE.Data;
using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Repository
{
    public class BookCategoryRepository : IRepository<int, BookCategory>
    {
        private readonly BookStoreDBContext _bookStoreDBContext;

        public BookCategoryRepository(BookStoreDBContext bookStoreDBContext)
        {
            _bookStoreDBContext = bookStoreDBContext;
        }

        public async Task<BookCategory> Add(BookCategory item)
        {
            _bookStoreDBContext.BookCategories.Add(item);
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }

        public async Task<BookCategory?> Delete(int key)
        {
            var bookCategory = await Get(key);
            if (bookCategory == null)
            {
                throw new NoSuchBookException();
            }
            else
            {
                _bookStoreDBContext.BookCategories.Remove(bookCategory);
                await _bookStoreDBContext.SaveChangesAsync();
                return bookCategory;
            }

            throw new NotImplementedException();
        }

        public async Task<BookCategory?> Get(int key)
        {
            var getBookCategories = await GetAll();
            var getBookCategory = getBookCategories.FirstOrDefault(g => g.BookCategoryId == key);
            if (getBookCategory != null)
            {
                return getBookCategory;
            }
            return null;

            //throw new BookCategoryNotFoundException();
        }

        public Task<List<BookCategory>?>? GetAll()
        {
            var getBookCategories = _bookStoreDBContext.BookCategories.ToListAsync();
            if (getBookCategories == null)
            {
                return null;
            }
            return getBookCategories;
        }

        public async Task<BookCategory> Update(BookCategory item)
        {
            _bookStoreDBContext.Entry<BookCategory>(item).State = EntityState.Modified;
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }
    }
}