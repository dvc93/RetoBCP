using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCambioMoneda.Services
{
    public static class DependenceService
    {
        public static IServiceCollection AddInjectionDependency(this IServiceCollection services)
        {
            #region business
            // services.AddScoped<IReturnBusiness, ReturnBusiness>();
            #endregion

            #region services
            // services.AddScoped<IReturnServices, ReturnServices>();
            #endregion

            #region logging
            // services.AddScoped<ICorrelationId, CorrelationId>();
            #endregion

            return services;
        }
    }
}
