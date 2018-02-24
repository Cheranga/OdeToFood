Custom Middleware
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



ASPNETCORE_ENVIRONMENT - Defines the environment