using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        [Column("Id_Pagamento")]
        [Display(Name = "Código do Pagamento")]

        public int PagamentoId { get; set; }

        [Column("FormaPagamento")]
        [Display(Name = "Forma do Pagamento")]
        public string FormaPagamento { get; set; } = string.Empty;
    }
}
