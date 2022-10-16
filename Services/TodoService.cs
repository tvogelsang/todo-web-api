using TodoWebApi.Entity;
using TodoWebApi.Services.Interfaces;

namespace TodoWebApi.Services
{
    public class TodoService : ITodoService
    {
        // Would typically store this in a persisted store
        private readonly IDictionary<Guid, Todo> _todo = new Dictionary<Guid, Todo>();

        /// <summary>
        /// Retrieve the Todo list for the user.
        /// </summary>
        /// 
        /// <param name="user">
        /// The User object.
        /// </param>
        /// 
        /// <returns>
        /// The result Todo object.
        /// </returns>
        public Todo Get(User user)
        {
            if (_todo.ContainsKey(user.Id))
            {
                return _todo[user.Id];
            }

            var todo = new Todo();

            _todo.Add(user.Id, todo);

            return todo;
        }
    }
}
