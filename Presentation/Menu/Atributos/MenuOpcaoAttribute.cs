using System;

namespace Presentation.Menu.Atributos
{
    internal class MenuOpcaoAttribute : Attribute
    {
        internal int Codigo { get; set; }
        internal string Descricao { get; set; }

        internal MenuOpcaoAttribute(int codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
        }
    }
}