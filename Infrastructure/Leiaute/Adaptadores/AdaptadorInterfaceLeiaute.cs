using System;
using Domain.Entities;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.Leiaute.Interfaces;
using static Infrastructure.Leiaute.Atributos.AtributosDtos;

namespace Infrastructure.Leiaute
{
    internal class AdaptadorInterfaceLeiaute
    {
        private readonly IJsonSource _jsonSource;

        public AdaptadorInterfaceLeiaute(IJsonSource jsonSource)
        {
            _jsonSource = jsonSource;
        }

        internal Linha[] TentarConverter(Type tipoLeiauteSelecionado)
        {
            try
            {
                var dto = _jsonSource.GetJsonObject(tipoLeiauteSelecionado);

                return ConverterLinhas(dto);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao tentar converter json em {tipoLeiauteSelecionado}: {erro.Message}");
            }

        }

        private Linha[] ConverterLinhas(object dto)
        {
            var linhas = new List<Linha>();

            var dtoEnumerable = dto as IEnumerable;

            foreach (var linha in dtoEnumerable)
            {
                var linhaConvertida = ConverterLinha(linha);
                linhas.Add(linhaConvertida);
            }

            return linhas.ToArray();
        }

        private Linha ConverterLinha(object dto)
        {
            var codigo = dto.GetType().GetCustomAttribute<CodigoLinhaAttribute>().Codigo;
            var linha = new Linha(codigo);

            foreach (var pripriedade in dto.GetType().GetProperties())
            {
                var valor = pripriedade.GetValue(dto);

                if (valor is IEnumerable<object>)
                {
                    var filhos = ConverterLinhas(valor);

                    foreach (var filho in filhos)
                    {
                        linha.AddFilho(filho);
                    }
                }
                else
                {
                    linha.AddDado(pripriedade.Name, valor);
                }
            }

            return linha;
        }
    }
}