namespace Application.UseCases.Interfaces
{
    public interface IConfiguradorBaseDadosUseCase
    {
        int[] ObterCodigosLeiaute();

        bool EhCodigoLeiauteValido(string codigoUsuario);

        bool EhCaminhoArquivoBaseDadosValido(string caminhoBaseDados);

        void AtualizarCaminhoBaseDados(int codigoLeiaute, string novoCaminhoArquivo);
    }
}