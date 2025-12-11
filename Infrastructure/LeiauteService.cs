using System;
using System.Linq;
using Domain.Entities;
using System.Reflection;
using Application.Interfaces;
using Infrastructure.Leiaute;
using static Infrastructure.Leiaute.Atributos.AtributosDtos;

namespace Infrastructure
{
    internal class LeiauteService : ILeiauteService
    {
        private readonly Type[] _tiposDtos;
        private readonly AdaptadorInterfaceLeiaute _adaptadorInterfaceLeiaute;

        public LeiauteService(AdaptadorInterfaceLeiaute adaptadorInterfaceLeiaute)
        {
            _tiposDtos = Assembly.GetExecutingAssembly()
              .GetTypes()
              .Where(w => w.GetCustomAttribute<LeiauteCodigoAttribute>() != null)
              .ToArray();

            _adaptadorInterfaceLeiaute = adaptadorInterfaceLeiaute;
        }

        public int[] TentarObterCodigosLeiaute()
        {
            try
            {
                return _tiposDtos.Select(s => s.GetCustomAttribute<LeiauteCodigoAttribute>().Codigo).ToArray();
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao tentar obter códigos de leiaute: {erro.Message}");
            }
        }

        public Linha[] TentarObterLinhasLeiaute(int codigoLeiaute)
        {
            try
            {
                var tipoLeiauteSelecionado = _tiposDtos
                .FirstOrDefault(f => f.GetCustomAttribute<LeiauteCodigoAttribute>().Codigo == codigoLeiaute);

                return _adaptadorInterfaceLeiaute.TentarConverter(tipoLeiauteSelecionado);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao obter linhas do leiaute: {erro.Message}");
            }
        }
    }
}