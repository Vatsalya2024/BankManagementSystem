using BOOKSTORE.Models.Entities;

namespace BOOKSTORE.Interface
{
    public interface IOrderService
    {
        public Task<Order> AddOrder(Order order);
        public Task<List<Order>> GetAllOrder();
        public Task<Order> GetOrderById(int id);
        public Task<Order> DeleteOrder(int id);
        public Task<Order> UpdateOrder(Order order);
    }
}
