using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BOOKSTORE.Service
{
    public class BookService : IBookService
    {
        private readonly IRepository<int, Book> _bookRepository;

        public BookService(IRepository<int, Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> AddBook(Book book)
        {
            return await _bookRepository.Add(book);
        }

        public async Task<Book> UpdateBook(Book book)
        {
            return await _bookRepository.Update(book);
        }

        public async Task<Book> DeleteBook(int bookId)
        {
            return await _bookRepository.Delete(bookId);
        }

       
    }
}