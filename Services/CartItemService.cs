using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using BOOKSTORE.Repository;

namespace BOOKSTORE.Services
{
    public class CartItemService : ICartItems
    {
        private readonly ILogger<CartItemService> _logger;
        private IRepository<int, CartItem> _cartItemRepository;

        public CartItemService(IRepository<int,CartItem> cartItemRepository,ILogger<CartItemService> logger)
        {
            _cartItemRepository = cartItemRepository;
            _logger= logger;
        }
        public async Task<CartItem> AddCartItems(CartItem cartItems)
        {
           return await _cartItemRepository.Add(  cartItems);
        }

        public async Task<bool> DeleteCartItems(int id)
        {
            var cartItem = await _cartItemRepository.Get(id);
            if (cartItem != null)
            {
                await _cartItemRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<List<CartItem>> GetAllCartItems()
        {
            return await _cartItemRepository.GetAll();
        }

        public async Task<CartItem> GetCartItemsById(int id)
        {
            var cartItems = await _cartItemRepository.GetAll();
            var cartItem = cartItems.FirstOrDefault(e => e.CartItemId == id);
            if (cartItem != null)

            {
                return cartItem;
            }
            throw new NoCartItemException();
        }

        public async Task<CartItem> UpdateCartItems(CartItem cartItems)
        {
            var cartItem = await _cartItemRepository.Get(cartItems.CartItemId);
            if (cartItems != null)
            {
                cartItems.Quantity = cartItem.Quantity;
               
                cartItems = await _cartItemRepository.Update(cartItems);
                return cartItems;

            }
            throw new NoCartItemException();

        }
    }
}
