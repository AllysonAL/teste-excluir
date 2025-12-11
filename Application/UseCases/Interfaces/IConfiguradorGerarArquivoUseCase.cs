namespace Application.UseCases.Interfaces
{
    public interface IConfiguradorGerarArquivoUseCase
    {
        bool EhCaminhoGerarArquivoValido(string caminhoGerarArquivo);

        void AtualizarCaminhoGerarArquivo(string novoCaminhoArquivo);
    }
}