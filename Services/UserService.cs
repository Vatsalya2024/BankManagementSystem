using BOOKSTORE.Exception;
using BOOKSTORE.Interface;
using BOOKSTORE.Mappers;
using BOOKSTORE.Models.DTOs;
using BOOKSTORE.Models.Entities;
using BOOKSTORE.Repository;
using Simplifly.Exceptions;
using System.Security.Cryptography;
using System.Text;

namespace BOOKSTORE.Services
{
    public class UserService : IUser
    {
        private readonly ILogger<UserService> _logger;
        private IRepository<int, User> _userRepository;
        public readonly ITokenService _tokenService;
        public UserService(IRepository<int, User> userRepository, ILogger<UserService> logger, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _logger = logger;
            _tokenService= tokenService;
            
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

        public async Task<Login> Login(Login user)
        {
            var myUser = await _userRepository.GetAll();
            var myUSer = myUser.FirstOrDefault(e => e.Username == user.Username);
            if (myUSer == null)
            {
                throw new InvlidUserException();
            }
            var userPassword = GetPasswordEncrypted(user.Password, myUSer.Key);
            var checkPasswordMatch = ComparePasswords(myUSer.Password, userPassword);
            if (checkPasswordMatch)
            {
                user.Password = "";
                user.Role = myUSer.Role;
                user.Token = await _tokenService.GenerateToken(user);
                return user;
            }
            throw new InvlidUserException();
        }

        public bool ComparePasswords(byte[] password, byte[] userPassword)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] != userPassword[i])
                    return false;
            }
            return true;
        }

        private byte[] GetPasswordEncrypted(string password, byte[] key)
        {
            HMACSHA512 hmac = new HMACSHA512(key);
            var userpassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return userpassword;
        }

        public async Task<Register> Register(Register user)
        {
            var users = await _userRepository.GetAll();
            var checkUser = users.FirstOrDefault(e => e.Username == user.Username);
            if (checkUser == null)
            {
                User myUser = new RegisterToUser(user).GetUser();
                myUser = await _userRepository.Add(myUser);
                Register result = new Register
                {
                    Username = myUser.Username,
                    Role = myUser.Role,

                };
                return result;
            }
            throw new UserAlreadyPresentException();
        }

        /*     public async Task<User> UpdateUser(User users)
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
             }*/
    }
}
