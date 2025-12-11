using System;

namespace Infrastructure.Leiaute.Atributos
{
    internal class AtributosDtos
    {
        [AttributeUsage(AttributeTargets.Class)]
        internal class LeiauteCodigoAttribute : Attribute
        {
            public int Codigo { get; }
            public LeiauteCodigoAttribute(int codigo) => Codigo = codigo;
        }

        [AttributeUsage(AttributeTargets.Class)]
        internal class ConfiguracaoCaminhoBaseDados : Attribute
        {
            public string ConfigKey { get; }
            public ConfiguracaoCaminhoBaseDados(string configKey) => ConfigKey = configKey;
        }

        [AttributeUsage(AttributeTargets.Class)]
        internal class CodigoLinhaAttribute : Attribute
        {
            public int Codigo { get; }
            public CodigoLinhaAttribute(int codigo) => Codigo = codigo;
        }
    }
}