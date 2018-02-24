# Custom Middleware
```C#
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
```

# Configuration Settings
* `ASPNETCORE_ENVIRONMENT` - Defines the current environment (Development, Staging, Production, etc.)
* You can add/modify/remove profiles, which can defined different environments (either through `launchSettings.json` or through project properties)
* You can use different configurations with "appsettings.[ENV].json". Once you have that, the configuration values will depend on the environment you choose.

# Setting up ASP.NET MVC
* Add the package dependency.
  * If you used the "Empty" template, in the project file there is already a meta package called `Microsoft.AspNetCore.All` which has the MVC. So no need to explicitly request anything.

* Add the MVC services.
  * In the `ConfigureServices` method call `services.AddMvc()` to register MVC services to be used in the request pipeline.

* Add the MVC middleware.
  * Use `app.UseMvcWithDefaultRoute` to install the MVC middleware.


# Setting Routes
> Setting of routes can be done in two ways.

* Conventional Routes
  * You can use `UseMvcWithDefaultRoute` inside the `Configure` method in `Startup` class, or you can the `UseMvc` Method and pass a method which configures the routes as you desire.

* Attribute Routing

