using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMercado.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Column("Id_Categoria")]
        [Display(Name = "Código do Produto")]

        public int CategoriaId { get; set; }


        [Column("NomeCategoria")]
        [Display(Name = "Nome do Categoria")]
        public string NomeCategoria { get; set; } = string.Empty;

    }
}
