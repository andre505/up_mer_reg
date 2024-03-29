﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace UPMerchantRegistration
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //old
            //CreateWebHostBuilder(args).Build().Run();
            //
            CreateWebHostBuilder(args).UseKestrel().UseIISIntegration().Build().Run();

            //var host = CreateWebHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        var context = services.GetRequiredService<UPAGENTMANAGERContext>();
            //        context.Database.EnsureCreated();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred creating the DB.");
            //    }
            //}

            ////host.Run();
            
            //    //var host = new WebHostBuilder()
            //    //    .UseKestrel()
            //    //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    //    .UseIISIntegration()
            //    //    .Build();

            //    //host.Run();
            }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
