using Presentation.Menu;
using Application.DependencyInjection;
using Presentation.DependencyInjection;
using Infrastructure.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddApplicationServices();
            services.AddPresentationServices();
            services.AddInfrastructureServices();

            var serviceProvider = services.BuildServiceProvider();

            serviceProvider
                .GetRequiredService<GerenciadorMenu>()
                .Executar();
        }
    }
}