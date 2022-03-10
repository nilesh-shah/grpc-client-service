using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace UserDetailsGrpcService
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Server is starting up ....");
            Console.WriteLine("Server is running on port 7042, waiting for the client communication ...");
            CreateHostBuilder(args).Build().Run();            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
