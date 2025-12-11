using System;

namespace Infrastructure.Leiaute.Interfaces
{
    public interface IJsonSource
    {
        object GetJsonObject(Type tipoDto);
    }
}