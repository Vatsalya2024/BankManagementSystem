using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.Identity.Client;

namespace BOOKSTORE.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<int, Order> _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IRepository<int, Order> orderRepository, ILogger<OrderService> logger)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }
        public async Task<Order> AddOrder(Order order)
        {
            return await _orderRepository.Add(order);
        }

        public async Task<Order> DeleteOrder(int id)
        {
            var order=await _orderRepository.Get(id);
            if (order != null)
            {
                await _orderRepository.Delete(id);
                return order;
            }
            throw new NoSuchOrderException();
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _orderRepository.GetAll();
        }

        public async Task<Order> GetOrderById(int id)
        {
            var orders = await _orderRepository.GetAll();
            var order = orders.FirstOrDefault(e => e.OrderId == id);
            if (order != null)
            {
                return order;
            }
            throw new NoSuchOrderException();

        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var orders=await _orderRepository.Get(order.OrderId);
            if (orders != null)
            {
                orders.UserId = order.UserId;
                orders.TotalAmount= order.TotalAmount;
                orders.Status= order.Status;
                orders=await _orderRepository.Update(orders);
                return orders;
            }
            throw new NoSuchOrderException();
        }
    }
}
