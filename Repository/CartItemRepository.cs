using BOOKSTORE.Data;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Repository
{
    public class CartItemRepository : IRepository<int, CartItem>
    {
        private readonly BookStoreDBContext _bookStoreDBContext;

        public CartItemRepository(BookStoreDBContext bookStoreDBContext)
        {
            _bookStoreDBContext = bookStoreDBContext;
        }

        public async Task<CartItem> Add(CartItem item)
        {
            _bookStoreDBContext.CartItems.Add(item);
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }

        public async Task<CartItem?> Delete(int key)
        {
            var cartItem = await Get(key);
            if (cartItem == null)
            {
                throw new Exception("CartItem not found.");
            }
            else
            {
                _bookStoreDBContext.CartItems.Remove(cartItem);
                await _bookStoreDBContext.SaveChangesAsync();
                return cartItem;
            }

            throw new NotImplementedException();
        }

        public async Task<CartItem?> Get(int key)
        {
            var getCartItems = await GetAll();
            var getCartItem = getCartItems.FirstOrDefault(g => g.CartItemId == key);
            if (getCartItem != null)
            {
                return getCartItem;
            }
            return null;

            //throw new CartItemNotFoundException();
        }

        public Task<List<CartItem>?>? GetAll()
        {
            var getCartItems = _bookStoreDBContext.CartItems.Include(a => a.Book).ToListAsync();
            if (getCartItems == null)
            {
                return null;
            }
            return getCartItems;
        }

        public async Task<CartItem> Update(CartItem item)
        {
            _bookStoreDBContext.Entry<CartItem>(item).State = EntityState.Modified;
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }
    }

}