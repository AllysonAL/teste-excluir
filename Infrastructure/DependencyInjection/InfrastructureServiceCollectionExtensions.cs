using System.IO;
using System.Configuration;
using Infrastructure.Config;
using Application.Interfaces;
using Infrastructure.Leiaute;
using Infrastructure.Leiaute.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    internal static class InfrastructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IConfigService, ConfigService>();
            services.AddSingleton<ILeiauteService, LeiauteService>();
            services.AddSingleton<AdaptadorInterfaceLeiaute>();
            services.AddSingleton<IJsonSource>(sp =>

            new AppConfigJsonSource(
                fileReader: File.ReadAllText,
                settingsReader: key => ConfigurationManager.AppSettings[key]
            ));

            return services;
        }
    }
}