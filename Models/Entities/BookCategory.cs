using System.ComponentModel.DataAnnotations.Schema;

namespace BOOKSTORE.Models.Entities
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        //public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        //public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
