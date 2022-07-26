using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareSample
{
    public class CustomMiddleware
    {
        //The middleware class must include:

        //A public constructor with a parameter of type RequestDelegate.
        //A public method named Invoke or InvokeAsync.This method must:
        //Return a Task.
        //Accept a first parameter of type HttpContext.
        private readonly RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;   
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("Called from Custom Middleware. \n");
        }
    }
}
