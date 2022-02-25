using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace QLTV.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<QLTVWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
