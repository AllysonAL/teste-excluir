using System;
using System.Linq;
using System.Reflection;
using Presentation.Helpers;
using System.Collections.Generic;
using Presentation.Menu.Atributos;
using Presentation.Menu.Opcoes.Interfaces;

namespace Presentation.Menu
{
    internal class GerenciadorMenu
    {
        private readonly Dictionary<int, (string descricao, IMenuOpcao opcao)> _menuOpcoes;

        public GerenciadorMenu(IEnumerable<IMenuOpcao> menuOpcoes)
        {
            _menuOpcoes = new Dictionary<int, (string descricao, IMenuOpcao opcao)>();

            foreach (var opcao in menuOpcoes)
            {
                var atributo = opcao.GetType().GetCustomAttribute<MenuOpcaoAttribute>();

                if (atributo != null)
                {
                    _menuOpcoes[atributo.Codigo] = (atributo.Descricao, opcao);
                }
            }
        }

        internal void Executar()
        {
            while (true)
            {
                ExibirMenu();
                var valorUsuario = Console.ReadLine();

                if (int.TryParse(valorUsuario, out int opcaoUsuario))
                {
                    if (_menuOpcoes.TryGetValue(opcaoUsuario, out var menuOpcao))
                    {
                        Console.Clear();
                        TentarExecutarOpcaoMenu(menuOpcao.opcao);
                    }
                }
                else
                {
                    Helper.ExibirValorInvalidoAguardarEnter();
                }
            }
        }

        private void ExibirMenu()
        {
            Console.WriteLine(@"- - - - - - - - MENU - - - - - - - -");
            Console.WriteLine();

            var menusOrdenadosPorCodigo = _menuOpcoes.OrderBy(o => o.Key);

            foreach (var menuOpcao in menusOrdenadosPorCodigo)
            {
                Console.WriteLine($"{menuOpcao.Key} - {menuOpcao.Value.descricao}");
            }

            Console.WriteLine();
            Console.WriteLine(@"- - - - - - - - - - - - - - - - - -");
            Console.WriteLine("Escolha uma opção: ");
        }

        private void TentarExecutarOpcaoMenu(IMenuOpcao opcao)
        {
            try
            {
                opcao.Executar();
            }
            catch (Exception erro)
            {
                Helper.VoltarAoMenuErroInesperado(erro.Message);
            }
        }
    }
}