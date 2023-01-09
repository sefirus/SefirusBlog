using Core.Entities;

namespace Core.Interfaces;

public interface IAuthService
{
    Task<string> Login(string email, string password);
    string CreateToken(User user);
}