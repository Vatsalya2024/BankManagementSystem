using BOOKSTORE.Models.DTOs;
using BOOKSTORE.Models.Entities;

namespace BOOKSTORE.Interface
{
    public interface IUser
    {
        public Task<User> AddUser(User user);
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(int id);
        public Task<bool> DeleteUser(int id);
        public Task<Login> Login(Login user);
        public Task<Register> Register(Register user);
        //public Task<User> UpdateUser(User user);

    }
}
