using System.ComponentModel.DataAnnotations.Schema;

namespace BOOKSTORE.Models.Entities
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }


        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book? Book { get; set; }

        public int Quantity { get; set; }
    }
}
