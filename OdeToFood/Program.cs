using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }


        //
        //  NOTE:
        //  *   The default web host builder will use "Kestrel" as the web server. It's a cross platform server.
        //  *   Integrates with IIS
        //  *   Have a default logging
        //  *   IConfiguration service made available
        //      *   JSON file (appsettings.json)
        //      *   User secrets file
        //      *   Environment variables
        //      *   Command line arguments
        //
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
