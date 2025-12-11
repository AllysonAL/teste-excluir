using System.Linq;
using Application.Interfaces;

namespace Application.Compartilhado
{
    internal class CodigosLeiauteService : ICodigosLeiauteService
    {
        private int[] _cacheCodigos;
        private readonly ILeiauteService _leiauteService;

        public CodigosLeiauteService(ILeiauteService leiauteService)
        {
            _leiauteService = leiauteService;
        }

        public bool EhCodigoLeiauteValido(string valor)
        {
            return
             int.TryParse(valor, out int codigo) &&
                ObterCodigosLeiaute().Contains(codigo);
        }

        public int[] ObterCodigosLeiaute()
        {
            if (_cacheCodigos is null)
            {
                _cacheCodigos = _leiauteService.TentarObterCodigosLeiaute().ToArray();
            }

            return _cacheCodigos;
        }
    }
}