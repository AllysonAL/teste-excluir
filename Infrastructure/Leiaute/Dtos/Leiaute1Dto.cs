using System.Linq;
using System.Collections.Generic;
using static Infrastructure.Leiaute.Atributos.AtributosDtos;

namespace Infrastructure.Leiaute.Dtos
{
    [LeiauteCodigo(1)]
    [ConfiguracaoCaminhoBaseDados("CaminhoBaseDadosLeiaute1")]

    [CodigoLinha(0)]
    internal class EmpresaDto
    {
        public string Cnpj { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public List<DocumentoDto> Documentos { get; set; }
    }

    [CodigoLinha(1)]
    internal class DocumentoDto
    {
        public string Modelo { get; set; }
        public string Numero { get; set; }
        public decimal Valor => Itens.Sum(s => s.Valor);
        public List<ItemDto> Itens { get; set; }
    }

    [CodigoLinha(2)]
    internal class ItemDto
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}