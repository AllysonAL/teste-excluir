using System;
using Presentation.Helpers;
using Presentation.Menu.Atributos;
using Application.UseCases.Interfaces;
using Presentation.Menu.Opcoes.Interfaces;

namespace Presentation.Menu.Opcoes
{
    [MenuOpcao(3, "Gerar arquivo")]
    internal class GeradorArquivoOpcao : IMenuOpcao
    {
        private readonly IGeradorArquivoUseCase _gerarArquivoUseCase;

        public GeradorArquivoOpcao(IGeradorArquivoUseCase gerarArquivoUseCase)
        {
            _gerarArquivoUseCase = gerarArquivoUseCase;
        }

        public void Executar()
        {
            var codigosDisponiveis = _gerarArquivoUseCase.ObterCodigosLeiaute();

            while (true)
            {
                Helper.ExibirMenuEscolherLeiaute(codigosDisponiveis);
                var respostaUsuario = Console.ReadLine();

                if (_gerarArquivoUseCase.EhCodigoLeiauteValido(respostaUsuario))
                {
                    Console.Clear();
                    ProcessarGerarArquivo(respostaUsuario);
                    break;
                }

                Helper.ExibirValorInvalidoAguardarEnter();
            }
        }

        private void ProcessarGerarArquivo(string respostaUsuario)
        {
            var codigoLeiaute = int.Parse(respostaUsuario);

            _gerarArquivoUseCase.TentarCriarArquivoNoCaminhoInformado(codigoLeiaute);

            Console.WriteLine("Arquivo gerado com sucesso!");
            Helper.VoltarAoMenuAguardarEnter();
        }
    }
}