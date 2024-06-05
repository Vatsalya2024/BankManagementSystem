using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Models.Entities;
using BOOKSTORE.Repository;

namespace BOOKSTORE.Services
{
    public class UserService : IUser
    {
        private readonly ILogger<UserService> _logger;
        private IRepository<int, User> _userRepository;
        public UserService(IRepository<int, User> userRepository, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
            
        }
        public async Task<User> AddUser(User user)
        {
            return await _userRepository.Add(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userRepository.Get(id);
            if (user != null)
            {
                await _userRepository.Delete(id);
                return true;
            }
            return false;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            var users = await _userRepository.GetAll();
            var user = users.FirstOrDefault(e => e.UserId == id);
            if (user != null)

            {
                return user;
            }
            throw new NoUserException("No Such User Found!");
        }

        public async Task<User> UpdateUser(User users)
        {
            var user = await _userRepository.Get(users.UserId);
            if (users != null)
            {
                
                users.Username = user.Username;
                users.Reviews = user.Reviews;
                users.Orders = user.Orders;
                users = await _userRepository.Update(users);
                return users;

            }
            throw new NoUserException("No Such User Found!");
        }
    }
}
