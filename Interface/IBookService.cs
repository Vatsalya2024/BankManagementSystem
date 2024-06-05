using BOOKSTORE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOOKSTORE.Interface
{
    public interface IBookService
    {
        public Task<Book> AddBook(Book book);
        public Task<List<Book>> GetAllBook();
        public Task<Book> GetBookById(int id);
        public Task<Book> DeleteBook(int id);
        public Task<Book> UpdateBook(Book book);
    }
}