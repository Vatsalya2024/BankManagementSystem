using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BOOKSTORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            try
            {
                var orderItems = await _orderService.GetAllOrder();
                return orderItems;
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder([FromBody] Order order)
        {
            try
            {
                var orders = await _orderService.AddOrder(order);
                return orders;
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Order>> UpdateOrder(int id, [FromBody] Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest("Order ID mismatch");
            }

            try
            {
                var orders = await _orderService.UpdateOrder(order);
                return Ok(orders);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            try
            {
                var orderItems = await _orderService.DeleteOrder(id);
                return Ok(orderItems);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
