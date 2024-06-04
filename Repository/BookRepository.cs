using BOOKSTORE.Data;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Repository
{
    public class BookRepository : IRepository<int, Book>
    {
        private readonly BookStoreDBContext _bookStoreDBContext;

        public BookRepository(BookStoreDBContext bookStoreDBContext)
        {
            _bookStoreDBContext = bookStoreDBContext;
            
        }
        public async Task<Book> Add(Book item)
        {
            var book = _bookStoreDBContext.Books.FirstOrDefault(b => b.Title == item.Title);
            if (book!=null)
            {
                throw new Exception();
                
            }
            _bookStoreDBContext.Books.Add(item);
            await _bookStoreDBContext.SaveChangesAsync();
            return item;

        }

        public async Task<Book?> Delete(int key)
        {
            var book = await Get(key);
            if (book == null)
            {
                throw new Exception();
            }
            else
            {
                _bookStoreDBContext.Books.Remove(book);
                await _bookStoreDBContext.SaveChangesAsync();
                return book;
            }

            throw new NotImplementedException();
        }

        public async Task<Book?> Get(int key)
        {
            var getbooks = await GetAll();
            var getbook = getbooks.FirstOrDefault(g => g.BookId == key);
            if (getbook!=null) 
            {
                return getbook;
            }
            return null;
            
            //throw new BookNotFoundException();
        }

        public Task<List<Book>?>? GetAll()
        {
            var getbooks = _bookStoreDBContext.Books.Include(a => a.BookCategories).Include(b => b.CartItems).Include(c => c.OrderItems).Include(d => d.Reviews).ToListAsync();
            if (getbooks == null)
            {
                return null;
                

            }
            return getbooks;
            
        }

        public async Task<Book> Update(Book item)
        {
            _bookStoreDBContext.Entry<Book>(item).State = EntityState.Modified;
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
            
        }
    }
}
