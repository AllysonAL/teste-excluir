namespace Application.Compartilhado
{
    public interface ICodigosLeiauteService
    {
        int[] ObterCodigosLeiaute();
        bool EhCodigoLeiauteValido(string valor);
    }
}