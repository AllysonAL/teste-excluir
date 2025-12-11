using System.IO;
using Application.Interfaces;
using Application.UseCases.Interfaces;

namespace Application.UseCases
{
    internal class ConfiguradorGerarArquivoUseCase : IConfiguradorGerarArquivoUseCase
    {
        private readonly IConfigService _configService;

        public ConfiguradorGerarArquivoUseCase(IConfigService configService)
        {
            _configService = configService;
        }

        public bool EhCaminhoGerarArquivoValido(string caminhoGerarArquivo)
        {
            return Directory.Exists(caminhoGerarArquivo);
        }

        public void AtualizarCaminhoGerarArquivo(string novoCaminhoArquivo)
        {
            _configService.AtualizarCaminhoGerarArquivos(novoCaminhoArquivo);
        }
    }
}