using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using BOOKSTORE.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOKSTORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItems _cartItems;
        public CartItemController(ICartItems cartItems)
        {
            _cartItems = cartItems;
        }
        [HttpGet]
        public async Task<ActionResult<List<CartItem>>> GetCartItems()
        {
            try
            {
                var cartItems = await _cartItems.GetAllCartItems();
                return cartItems;
            }
            catch(ApplicationException ex)
            {
                return NotFound(ex.Message);
            }            
            
        }

        [HttpPost]
        public async Task<ActionResult<CartItem>> AddBook([FromBody] CartItem cartItem)
        {
            try
            {
                var cartItems = await _cartItems.AddCartItems(cartItem);
                return cartItems;
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CartItem>> UpdateCartItems(int id, [FromBody] CartItem cartItem)
        {
            if (id != cartItem.CartItemId)
            {
                return BadRequest("Book ID mismatch");
            }

            try
            {
                var cartItems = await _cartItems.UpdateCartItems(cartItem);
                return Ok(cartItems);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CartItem>> DeleteBook(int id)
        {
            try
            {
                var cartItems = await _cartItems.DeleteCartItems(id);
                return Ok(cartItems);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
