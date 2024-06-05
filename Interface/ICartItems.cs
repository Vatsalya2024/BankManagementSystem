using BOOKSTORE.Models.Entities;

namespace BOOKSTORE.Interface
{
    public interface ICartItems
    {
        public Task<CartItem> AddCartItems(CartItem cartItems);
        public Task<List<CartItem>> GetAllCartItems();
        public Task<CartItem> GetCartItemsById(int id);
        public Task<bool> DeleteCartItems(int id);
        public Task<CartItem> UpdateCartItems(CartItem cartItems);
    }
}
