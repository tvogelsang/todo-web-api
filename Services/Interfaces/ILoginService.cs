using TodoWebApi.Entity;

namespace TodoWebApi.Services.Interfaces
{
    public interface ILoginService
    {
        string GenerateToken(User user);
        User GetUser(string token);
    }
}
