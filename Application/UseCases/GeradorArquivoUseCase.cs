using System;
using System.IO;
using System.Text;
using Application.Formatters;
using Application.Interfaces;
using Application.Compartilhado;
using Application.UseCases.Interfaces;

namespace Application.UseCases
{
    internal class GeradorArquivoUseCase : IGeradorArquivoUseCase
    {
        private readonly IConfigService _configService;
        private readonly ILeiauteService _leiauteService;
        private readonly ICodigosLeiauteService _codigosLeiauteService;
        private readonly ILinhaFormatter _linhaFormatter;

        private int _codigoLeiaute;

        public GeradorArquivoUseCase(ILeiauteService leiauteService, IConfigService configService,
            ICodigosLeiauteService codigosLeiauteService, ILinhaFormatter linhaFormatter)
        {
            _configService = configService;
            _leiauteService = leiauteService;
            _codigosLeiauteService = codigosLeiauteService;
            _linhaFormatter = linhaFormatter;
        }

        public int[] ObterCodigosLeiaute()
        {
            return _codigosLeiauteService.ObterCodigosLeiaute();
        }

        public bool EhCodigoLeiauteValido(string codigoUsuario)
        {
            return _codigosLeiauteService.EhCodigoLeiauteValido(codigoUsuario);
        }

        public void TentarCriarArquivoNoCaminhoInformado(int codigoLeiaute)
        {
            try
            {
                _codigoLeiaute = codigoLeiaute;

                var caminhoNome = ObterCaminhoNomeArquivo();
                var conteudo = ObterConteudoArquivo();

                File.WriteAllText(caminhoNome, conteudo, Encoding.UTF8);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao criar arquivo: {erro.Message}");
            }
        }

        private string ObterCaminhoNomeArquivo()
        {
            var caminhoGerarArquivo = _configService.TentarObterCaminhoGerarArquivos();
            var data = DateTime.Now.ToString("yyyyMMdd_HHmmss");

            return $@"{caminhoGerarArquivo}\LEIAUTE_[0{_codigoLeiaute}]_{data}.txt";
        }

        private string ObterConteudoArquivo()
        {
            var dadosArquivo = _leiauteService.TentarObterLinhasLeiaute(_codigoLeiaute);
            return _linhaFormatter.ObterConteudoFormatado(dadosArquivo);
        }
    }
}