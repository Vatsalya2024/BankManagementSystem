using BOOKSTORE.Models.DTOs;

namespace BOOKSTORE.Interface
{
    public interface ITokenService
    {
        public Task<string> GenerateToken(Login user);
    }
}
