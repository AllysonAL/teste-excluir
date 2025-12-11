using Application.UseCases;
using Application.Interfaces;
using Application.Formatters;
using Application.Compartilhado;
using Application.UseCases.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    internal static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IConfiguradorBaseDadosUseCase, ConfiguradorBaseDadosUseCase>();
            services.AddSingleton<IConfiguradorGerarArquivoUseCase, ConfiguradorGerarArquivoUseCase>();
            services.AddSingleton<IGeradorArquivoUseCase, GeradorArquivoUseCase>();
            services.AddSingleton<ICodigosLeiauteService, CodigosLeiauteService>();
            services.AddSingleton<ILinhaFormatter, LinhaFormatter>();

            return services;
        }
    }
}