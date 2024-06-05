using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using BOOKSTORE.Repository;

namespace BOOKSTORE.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IRepository<int, OrderItem> _orderItemRepository;
        private readonly ILogger<OrderItemService> _logger;

        public OrderItemService(IRepository<int, OrderItem> orderItemRepository, ILogger<OrderItemService> logger)
        {
            _orderItemRepository = orderItemRepository;
            _logger = logger;
        }
        public async Task<OrderItem> AddOrderItem(OrderItem orderItem)
        {
            return await _orderItemRepository.Add(orderItem);
        }

        public async Task<bool> DeleteOrderItem(int id)
        {
            var orderItem = await _orderItemRepository.Get(id);
            if (orderItem != null)
            {
                await _orderItemRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<List<OrderItem>> GetAllOrderItem()
        {
            var orderItem = await _orderItemRepository.GetAll();
            return orderItem;

        }

        public async Task<OrderItem> GetOrderItemById(int id)
        {
            var orderItems = await _orderItemRepository.Get(id);
            if (orderItems != null)
            {
                return orderItems;

            }
            throw new NoSuchOrderException();
        }

        public async Task<OrderItem> UpdateOrderItem(OrderItem orderItem)
        {
            var orderItems = await _orderItemRepository.Get(orderItem.OrderItemId);
            if (orderItems != null)
            {
                orderItems.Quantity = orderItem.Quantity;
                orderItems.Price = orderItem.Price;
                orderItems = await _orderItemRepository.Update(orderItems);
                return orderItems;

            }
            throw new NoSuchOrderException();
        }
    }
}
