using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    [Table("Vendedor")]
    public class Vendedor
    {
        [Column("Id_Vendedor")]
        [Display(Name = "Código do Vendedor")]

        public int VendedorId { get; set; }

        [Column("NomeVendedor")]
        [Display(Name = "Nome do Vendedor")]
        public string NomeVendedor { get; set; } = string.Empty;

        [Column("NumeroDoCaixa")]
        [Display(Name = "Número do Caixa")]
        public int NumeroDoCaixa { get; set; }
    }
}
