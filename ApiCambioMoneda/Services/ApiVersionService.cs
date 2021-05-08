using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ApiCambioMoneda.Services
{
    public  static class ApiVersionService
    {

        public static IServiceCollection AddApiVersions(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });

            return services;
        }
    }
}
