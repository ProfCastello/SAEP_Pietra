using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipamentosEletronicos.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatorio")]
        [StringLength(100)]
        [Display(Name = "Nome do produto")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A marca do produto é Obrigatória")]
        [StringLength(100)]
        [Display(Name = "Marca")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "A categoria do produto é obrigatória")]
        [StringLength(100)]
        [Display(Name = "Categoria")]
        public string? Categoria { get; set; }

        [Display(Name = "Código")]
        [StringLength(100)]
        public string? Codigo { get; set; }

        [Required(ErrorMessage = "O nome do fabricante deve ser informado")]
        [Display(Name = "Nome do fabricante")]
        public string? Fabricante { get; set; }

        [Required]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O estoque minimo não pode ser negativo")]
        [Display(Name = "Estoque minimo")]
        public int EstoqueMinimo { get; set; }

        [Required]
        [Display(Name = "Estoque Atual")]
        [Range(1, int.MaxValue, ErrorMessage = "O estoque atual não pode ser negativo")]
        public int EstoqueAtual { get; set; }

        [Required(ErrorMessage = "Informe as especificações tecnicas ")]
        [StringLength(100)]
        [Display(Name = "Especificações tecnicas")]
        public string? Observacao { get; set; }
    }
}
