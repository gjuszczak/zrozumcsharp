using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Zrozumcsharp.Services
{
    public class FirstRunSetupPageMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IFirstRunSetup firstRunSetup;
        private readonly FirstRunSetupPageOptions options;

        public FirstRunSetupPageMiddleware(RequestDelegate next, IFirstRunSetup firstRunSetup, IOptions<FirstRunSetupPageOptions> options)
        {
            this.next = next;
            this.firstRunSetup = firstRunSetup;
            this.options = options.Value;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            HttpRequest request = context.Request;
            if (await firstRunSetup.IsFirstRunSetupRequiredAsync() && request.Path != options.Path)
            {
                context.Response.Redirect($"https://{context.Request.Host}{options.Path}");
                return;
            }
            await next(context);
        }
    }

    public class FirstRunSetupPageOptions
    {
        public PathString Path { get; set; }
    }

    public static class FirstRunSetupPageMiddlewareExtensions
    {
        public static IApplicationBuilder UseFirstRunSetupPage(this IApplicationBuilder app, string path)
        {
            if (app == null)
            {
                throw new ArgumentNullException("app");
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("path");
            }
            return app.UseMiddleware<FirstRunSetupPageMiddleware>(new object[1]
            {
                Options.Create(new FirstRunSetupPageOptions
                {
                    Path = path
                })
            }) ;
        }
    }
}
