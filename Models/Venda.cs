using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    [Table("Venda")]
    public class Venda
    {
        [Column("Id_Venda")]
        [Display(Name = "Código da Venda")]

        public int VendaId { get; set; }

        [Column("ValorTotal")]
        [Display(Name = "Valor Total")]
        public double ValorTotal { get; set; }

        [Column("DataVenda")]
        [Display(Name = "Data da Venda")]
        public DateTime DataVenda { get; set; } 


        [ForeignKey("Id_Cliente")]
        public int Id_Cliente { get; set; }

        public Cliente? Cliente { get; set; }

        [ForeignKey("Id_Vendedor")]
        public int Id_Vendedor { get; set; }

        public Vendedor? Vendedor { get; set; }

        [ForeignKey("Id_Pagamento")]
        public int Id_Pagamento { get; set; }

        public Pagamento? Pagamento { get; set; }

        [NotMapped]
        public List<VendasHasProduto>? ProdutosList { get; set; }

    }
}
