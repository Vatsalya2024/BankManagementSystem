using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOKSTORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> AddOrderItem([FromBody] OrderItem orderItem)
        {
            try
            {
                var addedOrderItem = await _orderItemService.AddOrderItem(orderItem);
                return addedOrderItem;
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItem>> UpdateOrderItem(int id, [FromBody] OrderItem orderItem)
        {
            if (id != orderItem.OrderItemId)
            {
                return BadRequest("OrderItem ID mismatch");
            }

            try
            {
                var updatedOrderItem = await _orderItemService.UpdateOrderItem(orderItem);
                return Ok(updatedOrderItem);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderItem>> DeleteOrderItem(int id)
        {
            try
            {
                var deletedOrderItem = await _orderItemService.DeleteOrderItem(id);
                return Ok(deletedOrderItem);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
