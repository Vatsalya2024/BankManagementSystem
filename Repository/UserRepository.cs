using BOOKSTORE.Data;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BOOKSTORE.Repository
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly BookStoreDBContext _bookStoreDBContext;

        public UserRepository(BookStoreDBContext bookStoreDBContext)
        {
            _bookStoreDBContext = bookStoreDBContext;
        }
        public async Task<User> Add(User item)
        {
            _bookStoreDBContext.Users.Add(item);
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }

        public async Task<User?> Delete(int key)
        {
            var user = await Get(key);
            if (user == null)
            {
                throw new ApplicationException();
            }
            else
            {
                _bookStoreDBContext.Users.Remove(user);
                await _bookStoreDBContext.SaveChangesAsync();
                return user;
            }

            throw new NotImplementedException();
        }

        public async  Task<User?> Get(int key)
        {
            var getusers = await GetAll();
            var getuser = getusers.FirstOrDefault(g => g.UserId==key);
            if (getuser != null)
            {
                return getuser;
            }
            throw new NotImplementedException();
        }

        public Task<List<User>?> GetAll()
        {
            var getusers = _bookStoreDBContext.Users.ToListAsync();
            if (getusers == null)
            {
                return null;


            }
            return getusers;
        }

        public async Task<User> Update(User item)
        {
            _bookStoreDBContext.Entry<User>(item).State = EntityState.Modified;
            await _bookStoreDBContext.SaveChangesAsync();
            return item;
        }
    }
}
