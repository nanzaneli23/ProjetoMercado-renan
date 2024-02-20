using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("Id_Produto")]
        [Display(Name = "Código do Produto")]

        public int ProdutoId { get; set; }

        [Column("NomeProduto")]
        [Display(Name = "Nome do Produto")]
        public string NomeProduto { get; set; } = string.Empty;


        [Column("PrecoProduto")]
        [Display(Name = "Preço do Produto")]

        public double PrecoProduto { get; set; }

        [Column("QuantidadeEstoqueProduto")]
        [Display(Name = "Código do Produto")]

        public int QuantidadeEstoqueProduto { get; set; }

        [Column("NumeroDoCodigo")]
        [Display(Name = "Número do código de barra")]

        public int NumeroDoCodigo { get; set; }


        [ForeignKey("Id_Categoria")]
        public int Id_Categoria { get; set; }
        public Categoria? Categoria { get; set; }

        [ForeignKey("Id_Fornecedor")]
        public int Id_Fornecedor { get; set; }
        public Fornecedor? Fornecedor { get; set; }
    }
}
