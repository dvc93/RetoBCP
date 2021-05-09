using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interface;
using Service;
using Service.Interface;

namespace ApiCambioMoneda.Services
{
    public static class DependenceService
    {
        public static IServiceCollection AddInjectionDependency(this IServiceCollection services)
        {
            #region repository
            services.AddScoped<ICambioMonedaRepository, CambioMonedaRepository>();
            #endregion

            #region services
             services.AddScoped<ICambioMonedaService, CambioMonedaService>();
            #endregion

            #region logging
            
            #endregion

            return services;
        }
    }
}
