using System;
using Presentation.Helpers;
using Presentation.Menu.Atributos;
using Application.UseCases.Interfaces;
using Presentation.Menu.Opcoes.Interfaces;

namespace Presentation.Menu.Opcoes
{
    [MenuOpcao(2, "Configurar caminho para geração de arquivos")]
    internal class ConfiguradorGerarArquivoOpcao : IMenuOpcao
    {
        private readonly IConfiguradorGerarArquivoUseCase _configurarGerarArquivoUseCase;

        public ConfiguradorGerarArquivoOpcao(IConfiguradorGerarArquivoUseCase configurarGerarArquivoUseCase)
        {
            _configurarGerarArquivoUseCase = configurarGerarArquivoUseCase;
        }

        public void Executar()
        {
            while (true)
            {
                Console.WriteLine("Insira o novo caminho desejado para saída de arquivos gerados:");
                var caminhoUsuario = Console.ReadLine();

                if (_configurarGerarArquivoUseCase.EhCaminhoGerarArquivoValido(caminhoUsuario))
                {
                    Console.Clear();
                    ProcessarAtualizarCaminhoGerarArquivo(caminhoUsuario);
                    break;
                }

                Helper.ExibirValorInvalidoAguardarEnter();
            }
        }

        private void ProcessarAtualizarCaminhoGerarArquivo(string caminhoUsuario)
        {
            _configurarGerarArquivoUseCase.AtualizarCaminhoGerarArquivo(caminhoUsuario);

            Console.WriteLine("Caminho para gerar arquivo atualizado!");
            Helper.VoltarAoMenuAguardarEnter();
        }
    }
}