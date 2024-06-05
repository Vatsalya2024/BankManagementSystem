using BOOKSTORE.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BOOKSTORE.Interface
{
    public interface IBookService
    {
        Task<Book> AddBook(Book book);
        Task<Book> UpdateBook(Book book);
        Task<Book> DeleteBook(int bookId);
        
    }
}