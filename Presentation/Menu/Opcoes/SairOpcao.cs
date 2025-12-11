using System;
using Presentation.Menu.Atributos;
using Presentation.Menu.Opcoes.Interfaces;

namespace Presentation.Menu.Opcoes
{
    [MenuOpcao(0, "Sair")]
    internal class SairOpcao : IMenuOpcao
    {
        public void Executar()
        {
            const int FinalizadoExito = 0;

            Console.WriteLine("Finalizando o programa...");
            Environment.Exit(FinalizadoExito);
        }
    }
}