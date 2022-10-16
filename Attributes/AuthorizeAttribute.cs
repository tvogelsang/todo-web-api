using Microsoft.AspNetCore.Mvc;
using TodoWebApi.Filters;

namespace TodoWebApi.Attributes
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute() : base(typeof(AuthorizationFilter))
        {
            Console.Write("Word");
        }
    }
}
