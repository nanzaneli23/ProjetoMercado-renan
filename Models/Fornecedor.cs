using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{

    [Table("Fornecedor")]
    public class Fornecedor
    {
        [Column("Id_Fornecedor")]
        [Display(Name = "Código dos Fornecedor")]

        public int FornecedorId { get; set; }


        [Column("CnpjFornecedor")]
        [Display(Name = "Cnpj dos Fornecedor")]
        public string CnpjFornecedor { get; set; } = string.Empty;

        [Column("NomeFornecedor")]
        [Display(Name = "Nome dos Fornecedor")]
        public string NomeFornecedor { get; set; } = string.Empty;
    }
}
