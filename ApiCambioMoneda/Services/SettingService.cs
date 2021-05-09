using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace ApiCambioMoneda.Services
{
    public static class SettingService
    {
        public static IConfigurationRoot InitConfiguration(this IHostingEnvironment env)
        {
            var build = new ConfigurationBuilder()
             .SetBasePath(env.ContentRootPath)
             .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return build.AddEnvironmentVariables().Build();
        }
    }
}
