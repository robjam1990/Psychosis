using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;

namespace YourNamespace
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Applying custom logger middleware
            app.Use(async (context, next) =>
            {
                // Your custom logger logic here
                await next.Invoke();
            });

            // Applying middleware for authentication
            app.Use(async (context, next) =>
            {
                // Your authentication logic here
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Starting the server
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Server is now listening on port " + Environment.GetEnvironmentVariable("PORT") ?? "3000");
            });
        }
    }
}
