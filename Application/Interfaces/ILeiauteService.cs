using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILeiauteService
    {
        int[] TentarObterCodigosLeiaute();
        Linha[] TentarObterLinhasLeiaute(int codigoLeiaute);
    }
}