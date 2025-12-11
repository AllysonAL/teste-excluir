using System;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Serialization;
using Infrastructure.Leiaute.Interfaces;
using static Infrastructure.Leiaute.Atributos.AtributosDtos;

namespace Infrastructure.Leiaute
{
    internal class AppConfigJsonSource : IJsonSource
    {
        private readonly Func<string, string> _fileReader;
        private readonly Func<string, string> _settingsReader;

        public AppConfigJsonSource(
            Func<string, string> fileReader,
            Func<string, string> settingsReader)
        {
            _fileReader = fileReader;
            _settingsReader = settingsReader;
        }

        public object GetJsonObject(Type tipoDto)
        {
            try
            {
                var nomeConfigCaminho = tipoDto.GetCustomAttribute<ConfiguracaoCaminhoBaseDados>();
                var caminhoBaseDados = _settingsReader(nomeConfigCaminho.ConfigKey);
                if (caminhoBaseDados is null)
                {
                    throw new Exception("Não foi possível obter o caminho da fonte de dados");
                }

                var json = _fileReader(caminhoBaseDados);
                var options = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                return JsonConvert.DeserializeObject(json, tipoDto.MakeArrayType(), options);
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao desserializar json em objeto {tipoDto}: {erro.Message}");
            }
        }
    }
}