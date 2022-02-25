using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace QLTV
{
    public class QLTVWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<QLTVWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}