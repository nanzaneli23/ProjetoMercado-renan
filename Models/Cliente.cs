using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    [Table("Cliente")]
    public class Cliente
    {

        [Column("Id_Cliente")]
        [Display(Name = "Código do Cliente")]

        public int ClienteId { get; set; }

        [Column("NomeCliente")]
        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; } = string.Empty;

        [Column("TelefoneCliente")]
        [Display(Name = "Telefone do Cliente")]
        public int TelefoneCliente { get; set; } 

        [Column("CPFCliente")]
        [Display(Name = "CPF do Cliente")]
        public int CPFCliente { get; set; }

        [Column("NumeroDoCartao")]
        [Display(Name = "Número do Cartão")]
        public int NumeroDoCartao { get; set; }
    }
}
