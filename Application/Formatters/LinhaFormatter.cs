using System;
using System.Text;
using Domain.Entities;
using Domain.Extensions;

namespace Application.Formatters
{
    internal class LinhaFormatter : ILinhaFormatter
    {
        private Linha[] _linhas;
        private StringBuilder _montador;

        public string ObterConteudoFormatado(Linha[] dados)
        {
            _linhas = dados;
            _montador = new StringBuilder();

            EscreverLinhas();
            EscreverLinhasQtdTotalPorTipo();
            EscreverLinhaQtdTotal();

            return _montador.ToString();
        }

        private string EscreverLinhas()
        {
            foreach (var linha in _linhas)
            {
                EscreverLinha(linha);
                _montador.Append(Environment.NewLine);
            }

            return _montador.ToString();
        }

        private void EscreverLinha(Linha linha)
        {
            var identacao = new string(' ', linha.Codigo * 2);

            _montador.Append($"{identacao}0{linha.Codigo}|");

            foreach (var dado in linha.Dados)
            {
                _montador.Append($"{dado.Value}|");
            }

            foreach (var filho in linha.Filhos)
            {
                _montador.Append(Environment.NewLine);
                EscreverLinha(filho);
            }
        }

        private void EscreverLinhasQtdTotalPorTipo()
        {
            const string CodigoQtdTotalLinhasPorTipo = "09";

            foreach (var totalTipo in _linhas.ObterContagemPorCodigo())
            {
                _montador.Append(Environment.NewLine);
                _montador.Append($"{CodigoQtdTotalLinhasPorTipo}|{totalTipo.Codigo}|{totalTipo.Quantidade}");
            }
        }

        private void EscreverLinhaQtdTotal()
        {
            const string CodigoQtdTotal = "99";
            var qtdTotal = _linhas.ContarTodasAsLinhas();

            _montador.Append(Environment.NewLine);
            _montador.Append(Environment.NewLine);
            _montador.Append($"{CodigoQtdTotal}|{qtdTotal}");
        }
    }
}