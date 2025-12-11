using Presentation.Menu;
using Presentation.Menu.Opcoes;
using Presentation.Menu.Opcoes.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.DependencyInjection
{
    internal static class PresentationServiceCollectionExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddSingleton<GerenciadorMenu>();
            services.AddSingleton<IMenuOpcao, ConfiguradorBaseDadosOpcao>();
            services.AddSingleton<IMenuOpcao, ConfiguradorGerarArquivoOpcao>();
            services.AddSingleton<IMenuOpcao, GeradorArquivoOpcao>();
            services.AddSingleton<IMenuOpcao, SairOpcao>();

            return services;
        }
    }
}