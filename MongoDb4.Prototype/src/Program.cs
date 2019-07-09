using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDb4.Prototype.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace MongoDb4.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Debugger.Launch();

            var hostBuilder = new HostBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
                })
                .ConfigureServices((context, services) =>
                {
                    string connectionString = context.Configuration.GetConnectionString("MongoDb.Local");

                    services.AddTransient<IDatabase>(s => new Database(connectionString));
                    services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
                    services.AddTransient<IOrderRepository, OrderRepository>();

                    // Startup
                    services.AddSingleton<IHostedService, HostStartup>();
                })
                .ConfigureLogging((context, logging) =>
                {
                    logging.AddDebug();
                    logging.AddConsole();
                });

            Task.WaitAll(hostBuilder.RunConsoleAsync());
        }
    }
}
