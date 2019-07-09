using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Sonarqube.QualityGate.Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder appBuilder)
        {
            appBuilder.UseDeveloperExceptionPage();

            appBuilder.UseMvc();
        }
    }
}
