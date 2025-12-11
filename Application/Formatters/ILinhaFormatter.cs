using Domain.Entities;

namespace Application.Formatters
{
    public interface ILinhaFormatter
    {
        string ObterConteudoFormatado(Linha[] dados);
    }
}