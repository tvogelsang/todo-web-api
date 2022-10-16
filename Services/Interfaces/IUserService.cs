using TodoWebApi.Entity;

namespace TodoWebApi.Services.Interfaces
{
    public interface IUserService
    {
        User GetUser(string email);
    }
}
