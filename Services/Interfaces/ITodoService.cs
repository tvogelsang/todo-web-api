using TodoWebApi.Entity;

namespace TodoWebApi.Services.Interfaces
{
    public interface ITodoService
    {
        Todo Get(User user);
    }
}
