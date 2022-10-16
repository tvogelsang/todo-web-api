using TodoWebApi.Entity;
using TodoWebApi.Services.Interfaces;

namespace TodoWebApi.Services
{
    public class UserService : IUserService
    {
        // Using local memory instead of persisted storage
        private readonly IDictionary<String, User> _users = new Dictionary<String, User>(
            StringComparer.InvariantCultureIgnoreCase
        );

        /// <summary>
        /// Retrieve the User object by email.
        /// </summary>
        /// 
        /// <param name="email">
        /// The email address of the user.
        /// </param>
        /// 
        /// <returns>
        /// The result User object.
        /// </returns>
        public User GetUser(string email)
        {
            if (_users.ContainsKey(email))
            {
                return _users[email];
            }

            var user = new User(email);

            _users[email] = user;

            return user;
        }
    }
}
