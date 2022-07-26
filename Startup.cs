using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
                              ILogger<Startup> logger)
        {
            app.UseMiddleware<CustomMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();

            app.UseStaticFiles(); // use to serve static files under wwwroot folder

            app.Run(async(context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });

            //MiddlewareSample.Startup: Information: M1: Incoming Request
            //MiddlewareSample.Startup: Information: M2: Incoming Request
            //MiddlewareSample.Startup: Information: M3: Request handled and response produced
            //MiddlewareSample.Startup: Information: M2: Outgoing Response
            //MiddlewareSample.Startup: Information: M1: Outgoing Response

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("M1: Incoming Request");
            //    await next();
            //    logger.LogInformation("M1: Outgoing Response");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("M2: Incoming Request");
            //    await next();
            //    logger.LogInformation("M2: Outgoing Response");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("M3: Request handled and response produced");
            //    logger.LogInformation("M3: Request handled and response produced");
            //});

            //app.Use(async (context, next) =>                  
            //{
            //    await context.Response.WriteAsync("Hello from 1st Middleware!");
            //    await next();
            //});

            //app.Run(async (context) =>                  //terminal middleware
            //{
            //    await context.Response.WriteAsync("Hello from 2nd Middleware!");
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World Again!");
            //    });
            //});
        }
    }
}
