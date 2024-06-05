using BOOKSTORE.Data;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Repository
{
    public class OrderRepository: IRepository<int, Order>
    { 
            private readonly BookStoreDBContext _bookStoreDBContext;

            public OrderRepository(BookStoreDBContext bookStoreDBContext)
            {
                _bookStoreDBContext = bookStoreDBContext;
            }
            public async Task<Order> Add(Order item)
        { 
                _bookStoreDBContext.Orders.Add(item);
                await _bookStoreDBContext.SaveChangesAsync();
                return item;
            }

            public async Task<Order?> Delete(int key)
            {
                var order = await Get(key);
                if (order == null)
                {
                    throw new ApplicationException();
                }
                else
                {
                    _bookStoreDBContext.Orders.Remove(order);
                    await _bookStoreDBContext.SaveChangesAsync();
                    return order;
                }

                throw new NotImplementedException();
            }

            public async Task<Order?> Get(int key)
            {
                var getorders = await GetAll();
                var getorder = getorders?.FirstOrDefault(g => g.OrderId == key);
                if (getorder != null)
                {
                    return getorder;
                }
            throw new NotImplementedException();
        }

            public Task<List<Order>?> GetAll()
            {
                var getorders = _bookStoreDBContext.Orders.Include(a => a.OrderId).ToListAsync();
                if (getorders == null)
                {
                    return null;


                }
                return getorders;
            }

            public async Task<Order> Update(Order item)
            {
                _bookStoreDBContext.Entry<Order>(item).State = EntityState.Modified;
                await _bookStoreDBContext.SaveChangesAsync();
                return item;
            }
        }
    }

