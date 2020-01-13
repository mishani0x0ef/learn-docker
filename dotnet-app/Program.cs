using Learn.Docker.Repositories;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;

namespace Learn.Docker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            CreateDatabase(host);

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void CreateDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<BloggingContext>();

                for(var i = 0; i < 3; i++)
                {
                    try
                    {
                        context.Database.EnsureCreated();
                        break;
                    }
                    catch
                    {
                        // Wait until DB container started. MR
                        Thread.Sleep(2000);
                    }
                }
            }
        }
    }
}
