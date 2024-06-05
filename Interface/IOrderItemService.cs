using BOOKSTORE.Models.Entities;

namespace BOOKSTORE.Interface
{
    public interface IOrderItemService
    {
        public Task<OrderItem> AddOrderItem(OrderItem orderItem);
        public Task<List<OrderItem>> GetAllOrderItem();
        public Task<OrderItem> GetOrderItemById(int id);
        public Task<bool> DeleteOrderItem(int id);
        public Task<OrderItem> UpdateOrderItem(OrderItem orderItem);
    }
}
