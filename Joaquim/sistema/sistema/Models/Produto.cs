using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O Nome do produto é obrigatório.")]
        [StringLength(100)]
        [Display(Name = "Nome do Produto")]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O Código do produto é obrigatório.")]
        [StringLength(100)]
        [Display(Name = "Código")]
        public string? Codigo { get; set; }
        [Required(ErrorMessage = "A Fabricante do produto é obrigatória.")]
        [StringLength(100)]
        public string? Fabricante { get; set; }


        [Display(Name = "Especificações Técnicas")]
        [DataType(DataType.MultilineText)]
        public string? EspTecnicas { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "O Estoque Atual não pode ser negativo")]
        [Display(Name = "Estoque Atual")]
        public int EstoqueAtual { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "O Estoque Mínimo não pode ser negativo")]
        [Display(Name = "Estoque Mínimo")]
        public int EstoqueMinimo { get; set; }

        [Required]
        [Display(Name = "Preço de Custo")]
        [Column(TypeName = "decimal(10,2) ")]
        public decimal PrecoCusto { get; set; }
        [Required]
        [Display(Name = "Preço de Venda")]
        [Column(TypeName = "decimal(10,2) ")]
        public decimal PrecoVenda { get; set; }
    }
}
