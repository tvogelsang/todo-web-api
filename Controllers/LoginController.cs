using Microsoft.AspNetCore.Mvc;
using TodoWebApi.Services.Interfaces;

namespace TodoWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _authenticationService;
        private readonly IUserService _userService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILoginService authenticationService, IUserService userService, ILogger<LoginController> logger)
        {
            _authenticationService = authenticationService;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult Post([FromBody] string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return BadRequest();
            }

            var user = _userService.GetUser(email);

            if (user == null)
            {
                return BadRequest($"{email} could not be found");
            }

            var token = _authenticationService.GenerateToken(user);

            return Ok(new
            {
                token
            });
        }
    }
}