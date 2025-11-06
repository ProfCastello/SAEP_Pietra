using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EquipamentosEletronicos.Models
{
    public class Movimentacao
    {
        public int MovimentacaoId { get; set; }

        [Required(ErrorMessage = "O produto é obrigatório")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }
        public string? UsuarioId { get; set; }
        public IdentityUser? Usuario { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "digite um quantidade válida")]
        public int Quantidade { get; set; }

        [Required]
        [AllowedValues("E", "S", ErrorMessage = "Selecione o tipo de movimentação entre entradas ou Saidas")]
        public string? Tipo { get; set; }
    }
}
