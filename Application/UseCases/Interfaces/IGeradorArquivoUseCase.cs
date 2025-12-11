namespace Application.UseCases.Interfaces
{
    public interface IGeradorArquivoUseCase
    {
        int[] ObterCodigosLeiaute();

        bool EhCodigoLeiauteValido(string codigoUsuario);

        void TentarCriarArquivoNoCaminhoInformado(int codigoLeiaute);
    }
}