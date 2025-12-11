using System;
using System.Linq;
using System.Reflection;
using System.Configuration;
using Application.Interfaces;
using static Infrastructure.Leiaute.Atributos.AtributosDtos;

namespace Infrastructure.Config
{
    internal class ConfigService : IConfigService
    {
        const string NomeConfigCaminhoGerarArquivos = "CaminhoGerarArquivos";

        private readonly Type[] _tiposDtos;

        public ConfigService()
        {
            _tiposDtos = Assembly.GetExecutingAssembly()
              .GetTypes()
              .Where(w => w.GetCustomAttribute<LeiauteCodigoAttribute>() != null)
              .ToArray();
        }

        public void TentarAtualizarCaminhoBaseDados(int codigoLeiaute, string novoCaminho)
        {
            var nomeConfig = TentarObterNomeConfigCaminhoBaseDados(codigoLeiaute);

            TentarAtualizarConfig(nomeConfig, novoCaminho);
        }

        private string TentarObterNomeConfigCaminhoBaseDados(int codigoLeiaute)
        {
            try
            {
                return _tiposDtos
                .FirstOrDefault(f => f.GetCustomAttribute<LeiauteCodigoAttribute>().Codigo == codigoLeiaute)
                .GetCustomAttribute<ConfiguracaoCaminhoBaseDados>().ConfigKey;
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao obter config caminho base de dados: {erro.Message}");
            }
        }

        private void TentarAtualizarConfig(string chave, string valor)
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.AppSettings.Settings[chave].Value = valor;
                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao atualizar aquivo de configuração: {erro.Message}");
            }
        }

        public void AtualizarCaminhoGerarArquivos(string novoCaminho)
        {
            TentarAtualizarConfig(NomeConfigCaminhoGerarArquivos, novoCaminho);
        }

        public string TentarObterCaminhoGerarArquivos()
        {
            try
            {
                return ConfigurationManager.AppSettings[NomeConfigCaminhoGerarArquivos];
            }
            catch (Exception erro)
            {
                throw new Exception($"Erro ao obter caminho {NomeConfigCaminhoGerarArquivos}: {erro.Message}");
            }
        }
    }
}