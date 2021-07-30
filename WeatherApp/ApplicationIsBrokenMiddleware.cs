using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WeatherApp
{
    public class ApplicationBrokenMiddleware : IMiddleware
    {
        private readonly IBreakApplicationService _breakApplication;

        public ApplicationBrokenMiddleware(IBreakApplicationService breakApplication)
        {
            if (breakApplication == null)
            {
                throw new ArgumentNullException(nameof(breakApplication));
            }

            _breakApplication = breakApplication;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (_breakApplication.IsApplicationBroken)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Panic at Disco!");
                return;
            }

            await next(context);
        }
    }
}
