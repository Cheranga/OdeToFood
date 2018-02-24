using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IGreeter greeter,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Use(next =>
           {
               //
               //   NOTE:
               //   This is the inner function which is considered as the middleware
               //   and will be called per each HTTP request
               //
               return async context =>
               {
                   logger.LogInformation($"Request Received {DateTime.UtcNow.ToString("HH:mm:ss")}");

                   if (context.Request.Path.StartsWithSegments("/mym"))
                   {
                       await context.Response.WriteAsync(greeter.GetMessageOfTheDay());
                       logger.LogInformation($"Request Handled {DateTime.UtcNow.ToString("HH:mm:ss")}");
                   }
                   else
                   {
                       await next(context);
                       logger.LogInformation("Response outgoing");
                   }
               };
           });


            app.UseWelcomePage(new WelcomePageOptions
            {
                Path = "/wp"
            });

            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
