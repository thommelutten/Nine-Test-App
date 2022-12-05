using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.Http;

namespace NineTestApp.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddUrlGroup(new Uri("http://www.google.com"), "Google Webpage", HealthStatus.Unhealthy, timeout: new TimeSpan(0, 0, 5));

            return services;
        }
    }
}