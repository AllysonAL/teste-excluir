using System;
using System.IO;
using Application.Interfaces;
using Application.Compartilhado;
using Application.UseCases.Interfaces;

namespace Application.UseCases
{
    internal class ConfiguradorBaseDadosUseCase : IConfiguradorBaseDadosUseCase
    {
        private readonly IConfigService _configService;
        private readonly ICodigosLeiauteService _codigosLeiauteService;

        public ConfiguradorBaseDadosUseCase(IConfigService configService, ICodigosLeiauteService codigosLeiauteService)
        {
            _configService = configService;
            _codigosLeiauteService = codigosLeiauteService;
        }

        public int[] ObterCodigosLeiaute()
        {
            return _codigosLeiauteService.ObterCodigosLeiaute();
        }

        public bool EhCodigoLeiauteValido(string codigoUsuario)
        {
            return _codigosLeiauteService.EhCodigoLeiauteValido(codigoUsuario);
        }

        public bool EhCaminhoArquivoBaseDadosValido(string caminhoBaseDados)
        {
            return File.Exists(caminhoBaseDados) &&
                Path.GetExtension(caminhoBaseDados).Equals(".json", StringComparison.OrdinalIgnoreCase);
        }

        public void AtualizarCaminhoBaseDados(int codigoLeiaute, string novoCaminhoArquivo)
        {
            _configService.TentarAtualizarCaminhoBaseDados(codigoLeiaute, novoCaminhoArquivo);
        }
    }
}