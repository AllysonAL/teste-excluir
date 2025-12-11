using System.Linq;
using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Extensions
{
    public static class LinhaExtensions
    {
        public static List<CodigoContagem> ObterContagemPorCodigo(this IEnumerable<Linha> linhas)
        {
            IEnumerable<int> ObterCodigosRecursivo(Linha linha)
            {
                return new[] { linha.Codigo }
                    .Concat(linha.Filhos.SelectMany(s => ObterCodigosRecursivo(s)));
            }

            return linhas
                .SelectMany(s => ObterCodigosRecursivo(s))
                .GroupBy(g => g)
                .Select(s => new CodigoContagem
                {
                    Codigo = s.Key,
                    Quantidade = s.Count()
                })
                .ToList();
        }

        public static int ContarTodasAsLinhas(this IEnumerable<Linha> linhas)
        {
            int ContarRecursivo(Linha linha)
            {
                return 1 + linha.Filhos.Sum(s => ContarRecursivo(s));
            }

            return linhas.Sum(s => ContarRecursivo(s));
        }
    }
}