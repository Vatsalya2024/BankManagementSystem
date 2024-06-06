using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;

namespace BOOKSTORE.Services
{
    public class BookService : IBookService
    {
        private readonly IRepository<int, Book> _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IRepository<int, Book> bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public async Task<Book> AddBook(Book book)
        {
            var books= await _bookRepository.Add(book);
            
            return books;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var book=await _bookRepository.Get(id); 
            if(book!=null)
            {
                book=await _bookRepository.Delete(id);
                return book;
            }
            throw new NoSuchBookException();
        }

        public async Task<List<Book>> GetAllBook()
        {
            var books=await _bookRepository.GetAll();
            return books;

        }

        public async Task<Book> GetBookById(int id)
        {
            var books=await _bookRepository.Get(id);
            if (books != null)
            {
                return books;

            }
            throw new NoSuchBookException();
        }

        public async Task<List<Book>> SearchBook(string bookName)
        {
            var books = await _bookRepository.GetAll();
            var book = books.Where(e => e.Title == bookName).ToList();
            if(book != null)
            {
                return book;
            }
            throw new NoSuchBookException();
        }

        public async Task<Book> UpdateBook(Book book)
        {
            var books=await _bookRepository.Get(book.BookId);
            if(books != null)
            {
                books.Author = book.Author;
                books.Description = book.Description;
                books.Price = book.Price;
                books.StockQuantity=book.StockQuantity;
                books.Title=book.Title;
                books=await _bookRepository.Update(book);
                return books;

            }
            throw new NoSuchBookException();
        }
    }
}
