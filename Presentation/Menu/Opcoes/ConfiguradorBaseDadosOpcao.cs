using System;
using Presentation.Helpers;
using Presentation.Menu.Atributos;
using Application.UseCases.Interfaces;
using Presentation.Menu.Opcoes.Interfaces;

namespace Presentation.Menu.Opcoes
{
    [MenuOpcao(1, "Configurar caminhos de arquivos de bases de dados")]
    internal class ConfiguradorBaseDadosOpcao : IMenuOpcao
    {
        private readonly IConfiguradorBaseDadosUseCase _configurarBaseDadosUseCase;

        public ConfiguradorBaseDadosOpcao(IConfiguradorBaseDadosUseCase configurarBaseDadosUseCase)
        {
            _configurarBaseDadosUseCase = configurarBaseDadosUseCase;
        }

        public void Executar()
        {
            var codigosDisponiveis = _configurarBaseDadosUseCase.ObterCodigosLeiaute();

            while (true)
            {
                Helper.ExibirMenuEscolherLeiaute(codigosDisponiveis);
                var codigoUsuario = Console.ReadLine();

                if (_configurarBaseDadosUseCase.EhCodigoLeiauteValido(codigoUsuario))
                {
                    Console.Clear();
                    DefinirNovoCaminho(codigoUsuario);
                    break;
                }

                Helper.ExibirValorInvalidoAguardarEnter();
            }
        }

        private void DefinirNovoCaminho(string codigoUsuario)
        {
            while (true)
            {
                var codigo = int.Parse(codigoUsuario);

                Console.WriteLine($"Insira o novo caminho do arquivo de dados do Leiaute{codigo}:");
                var caminhoUsuario = Console.ReadLine();

                if (_configurarBaseDadosUseCase.EhCaminhoArquivoBaseDadosValido(caminhoUsuario))
                {
                    Console.Clear();
                    ProcessarAtualizarArquivoBasesDados(codigo, caminhoUsuario);
                    break;
                }

                Helper.ExibirValorInvalidoAguardarEnter();
            }
        }

        private void ProcessarAtualizarArquivoBasesDados(int codigo, string caminhoUsuario)
        {
            _configurarBaseDadosUseCase.AtualizarCaminhoBaseDados(codigo, caminhoUsuario);

            Console.WriteLine("Caminho para gerar arquivo atualizado!");
            Helper.VoltarAoMenuAguardarEnter();
        }
    }
}