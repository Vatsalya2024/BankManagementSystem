using BOOKSTORE.Models.DTOs;
using BOOKSTORE.Models.Entities;
using System.Security.Cryptography;
using System.Text;

namespace BOOKSTORE.Mappers
{
    public class RegisterToUser
    {
        User user;
        public RegisterToUser(Register register)
        {
            user = new User();
            user.Username = register.Username;
            user.Email = register.Email;
            user.Role = register.Role;
            GetPassword(register.Password);
        }
        private void GetPassword(string password)
        {
            HMACSHA512 hmac = new HMACSHA512();
            user.Key = hmac.Key;
            user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }
        public User GetValidation()
        {
            return user;
        }

        public User GetUser()
        {
            return user;
        }
    }
}
