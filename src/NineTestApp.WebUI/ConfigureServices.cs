using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json.Linq;
using NineTestApp.Application.Common.Interfaces;
using NineTestApp.Infrastructure.Repositories;

namespace NineTestApp.WebUI
{
    public static class ConfigureServices
    {

        public static IServiceCollection AddWebUIServices(this IServiceCollection services)
        {
            return services;
        }

        public static void AddHealthCheckEndpoint(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions()
            {
                ResultStatusCodes =
                {
                    [HealthStatus.Healthy] = StatusCodes.Status200OK,
                    [HealthStatus.Degraded] = StatusCodes.Status500InternalServerError,
                    [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                },
                ResponseWriter = WriteHealthCheckResponse,
                AllowCachingResponses = false
            });
        }

        private static Task WriteHealthCheckResponse(HttpContext httpContext, HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";

            var json = new JObject(
                new JProperty("Version", GetVersion()),
                new JProperty("OverallStatus", result.Status.ToString()),
                new JProperty("TotalChecksDuration", result.TotalDuration.TotalSeconds.ToString("0:0.00")),
                new JProperty("DependencyHealthChecks", new JObject(result.Entries.Select(dicItem =>
                    new JProperty(dicItem.Key, new JObject(
                        new JProperty("Status", dicItem.Value.Status.ToString()),
                        new JProperty("Duration", dicItem.Value.Duration.TotalSeconds.ToString("0:0.00")),
                        new JProperty("Exception", dicItem.Value.Exception?.Message),
                        new JProperty("Data", new JObject(dicItem.Value.Data.Select(dicData =>
                            new JProperty(dicData.Key, dicData.Value))))
                        ))
                    )))
                );
            return httpContext.Response.WriteAsync(json.ToString(Newtonsoft.Json.Formatting.Indented));
        }

        private static string GetVersion()
        {
            if (File.Exists("version.txt"))
            {
                return File.ReadAllText("version.txt");
            }
            else
            {
                return "Unable to read version";
            }
        }
    }
}
