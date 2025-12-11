using System;

namespace Presentation.Helpers
{
    internal static class Helper
    {
        internal static void ExibirMenuEscolherLeiaute(int[] codigosDisponiveis)
        {
            Console.WriteLine("Selecione o leiaute desejado:");
            Console.WriteLine();

            foreach (var codigo in codigosDisponiveis)
            {
                Console.WriteLine($"{codigo} - Leiaute{codigo}");
            }

            Console.WriteLine();
        }

        internal static void ExibirValorInvalidoAguardarEnter()
        {
            Console.WriteLine();
            Console.WriteLine("Valor inválido, pressione ENTER para escolher novamente");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void VoltarAoMenuAguardarEnter()
        {
            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para voltar ao menu");
            Console.ReadKey();
            Console.Clear();
        }

        internal static void VoltarAoMenuErroInesperado(string erroMessage)
        {
            Console.WriteLine($"Infelizmente ocorreu um erro inesperado: {erroMessage}");
            VoltarAoMenuAguardarEnter();
        }
    }
}