using System.Collections.Generic;

namespace Domain.Entities
{
    public class Linha
    {
        public int Codigo { get; set; }
        public Dictionary<string, object> Dados { get; set; }
        public List<Linha> Filhos { get; set; }

        public Linha(int codigo)
        {
            Codigo = codigo;
            Dados = new Dictionary<string, object>();
            Filhos = new List<Linha>();
        }

        public void AddDado(string nome, object valor)
        {
            Dados[nome] = valor;
        }

        public void AddFilho(Linha filho)
        {
            Filhos.Add(filho);
        }
    }
}