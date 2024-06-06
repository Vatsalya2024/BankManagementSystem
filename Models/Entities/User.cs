using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace BOOKSTORE.Models.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Key { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}
