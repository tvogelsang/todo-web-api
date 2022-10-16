using TodoWebApi.Entity;
using TodoWebApi.Services.Interfaces;

namespace TodoWebApi.Services
{
    public class LoginService : ILoginService
    {
        // Would typically store this in a cache backed with a persisted store
        private readonly IDictionary<String, User> _authenticatedUsers = new Dictionary<String, User>();
        private readonly IUserService _userService;

        public LoginService(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Handles the authentication of the user.
        /// </summary>
        /// 
        /// <param name="user">
        /// The User object.
        /// </param>
        /// 
        /// <returns>
        /// The result authentication token.
        /// </returns>
        public string GenerateToken(User user)
        {
            var token = Guid.NewGuid().ToString();

            _authenticatedUsers[token] = user;

            return token;
        }

        /// <summary>
        /// Retrieve the authenticated user.
        /// </summary>
        /// 
        /// <param name="token">
        /// The authentication token.
        /// </param>
        /// 
        /// <returns>
        /// The result User object.
        /// </returns>
        public User GetUser(string token)
        {
            if (_authenticatedUsers.ContainsKey(token))
            {
                return _authenticatedUsers[token];
            }

            return null;
        }
    }
}
