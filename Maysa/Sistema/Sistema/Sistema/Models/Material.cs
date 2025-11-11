using System.ComponentModel.DataAnnotations;

namespace Sistema.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [StringLength(100)]
        [Display(Name = "Nome do Material")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [StringLength(100)]
        public string? Categoria { get; set; }

        [StringLength(100)]
        [Display(Name = "Especificação")]
        public string? Especificacao { get; set; }

        [Required]
        [AllowedValues("K", "M", "L", ErrorMessage = "Verifique a unidade de medida do material.")]
        [Display(Name = "Unidade de Medida")]
        public string? Unidade { get; set; }

        [Required]
        [AllowedValues("P", "N", ErrorMessage = "Verifique se o material possui validade.")]
        [Display(Name = "Esse material possui vencimento?")]
        public string? Vencimento { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O número não pode ser negativo.")]
        [Display(Name = "Estoque Atual")]
        public int EstoqueAtual { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O número não pode ser negativo.")]
        [Display(Name = "Estoque Mínimo")]
        public int EstoqueMinimo { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida.")]
        [Display(Name = "Data de Validade")]
        public DateTime? DataValidade { get; set; }
    }
}
