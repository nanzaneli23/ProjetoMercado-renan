using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    [Table("VendasHasProduto")]
    public class VendasHasProduto
    {
        [Column("VendasHasProdutoId")]
        [Display(Name = "Código da Venda do Produto")]
        public int VendasHasProdutoId { get; set; }

        [ForeignKey("VendaId")]
        public int VendaId { get; set; }
        public Venda? Venda { get; set; }

        [ForeignKey("ProdutoId")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        [Column("QuantidadeVendaHas")]
        [Display(Name = "Quantidade")]

        public int QuantidadeVendaHas { get; set; }
    }
}
