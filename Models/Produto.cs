using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueEquipEletro.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "A Marca do produto é Obrigatório!")]
        [StringLength(100)]
        [Display(Name = "Marca")]
        public string? Marca { get; set; }

        [Display(Name = "Código do produto")]
        [StringLength(100)]
        public string? Código { get; set; }


        [Required(ErrorMessage = "O Modelo do Produto é Obrigatório!")]
        [StringLength(100)]
        [Display(Name = "Modelo")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Escolha a categoria do Produto")]
        [StringLength(100)]
        [AllowedValues("SmartPhone", "Tablet", "Notebook", "Smart Tv", "Acessórios", "Outros")]
        [Display(Name = "Categoria")]
        public string? Categoria { get; set; }

        [Required(ErrorMessage = "O Fabricante é Obrigatório!")]
        [StringLength(100)]
        [Display(Name = "Fabricante")]
        public string? Fabricante { get; set; }

        [Display(Name = "Observação")]
        [DataType(DataType.MultilineText)]
        public string? Observação { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O Estoque Atual não pode estar vazio!")]
        [Display(Name = "Estoque Atual")]
        public int EstoqueAtual { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O Estoque não pode estar vazio!")]
        [Display(Name = "Estoque Minimo")]
        public int EstoqueMinimo { get; set; }

        [Required]
        [Display(Name = "Preço de custo")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? PrecoCusto { get; set; }

        [Required]
        [Display(Name = "Preço de Venda")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal? PrecoVenda { get; set; }
    }
}
