using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TodoWebApi.Services.Interfaces;

namespace TodoWebApi.Filters
{
    public class AuthorizationFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request?
                .Headers["authorization"]
                .ToString();

            if (String.IsNullOrEmpty(token))
            {
                context.Result = new BadRequestResult();
            }
            else
            {
                var loginService = context.HttpContext.RequestServices.GetService<ILoginService>();

                var user = loginService.GetUser(token);

                if (user == null)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                }
                else
                {
                    context.HttpContext.Items["User"] = user;
                }
            }
        }
    }
}
