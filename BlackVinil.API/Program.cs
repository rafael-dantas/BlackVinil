using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlackVinil.API.Controllers;
using BlackVinil.Application.Interfaces;
using BlackVinil.IoC;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BlackVinil.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            //ModuleResolve.Wire(Module.Create());
            //ModuleResolve.Resolve<Program>();
            CreateWebHostBuilder(args).Build().Run();            

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
