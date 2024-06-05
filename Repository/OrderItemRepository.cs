using BOOKSTORE.Data;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Repository
{
    public class OrderItemRepository : IRepository<int, OrderItem>
    {
        private readonly BookStoreDBContext _bookStoreDBContext;

        public OrderItemRepository(BookStoreDBContext bookStoreDBContext)
        {
            _bookStoreDBContext = bookStoreDBContext;
        }

        public async Task<OrderItem> Add(OrderItem item)
        {
            _bookStoreDBContext.OrderItems.Add(item);
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }

        public async Task<OrderItem?> Delete(int key)
        {
            var orderItem = await Get(key);
            if (orderItem == null)
            {
                throw new ApplicationException("OrderItem not found.");
            }
            else
            {
                _bookStoreDBContext.OrderItems.Remove(orderItem);
                await _bookStoreDBContext.SaveChangesAsync();
                return orderItem;
            }

            throw new NotImplementedException();
        }

        public async Task<OrderItem?> Get(int key)
        {
            var getOrderItems = await GetAll();
            var getOrderItem = getOrderItems.FirstOrDefault(g => g.OrderItemId == key);
            if (getOrderItem != null)
            {
                return getOrderItem;
            }
            return null;

            //throw new OrderItemNotFoundException();
        }

        public Task<List<OrderItem>?>? GetAll()
        {
            var getOrderItems = _bookStoreDBContext.OrderItems.Include(a => a.Book).ToListAsync();
            if (getOrderItems == null)
            {
                return null;
            }
            return getOrderItems;
        }

        public async Task<OrderItem> Update(OrderItem item)
        {
            _bookStoreDBContext.Entry<OrderItem>(item).State = EntityState.Modified;
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }
    }
}