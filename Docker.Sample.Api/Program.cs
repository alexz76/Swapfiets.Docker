using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Docker.Sample.Api
{
    public static class Program
    {
        public static void Main(string[] args)
            => WebHost
                .CreateDefaultBuilder()
                .UseStartup<Startup>()
                .Build()
                .Run();
    }
}
