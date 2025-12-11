namespace Application.Interfaces
{
    public interface IConfigService
    {
        string TentarObterCaminhoGerarArquivos();
        void AtualizarCaminhoGerarArquivos(string novoCaminho);
        void TentarAtualizarCaminhoBaseDados(int codigoLeiaute, string novoCaminho);
    }
}