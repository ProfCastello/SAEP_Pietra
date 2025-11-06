using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace EstoqueEquipEletro.Models
{
    public class Movimentacao
    {
        public int MovimentacaoId { get; set; }

        [Required]
        [Display(Name = "Produto")]

        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }

        public string? UsuarioId { get; set; }
        public IdentityUser? Usuario { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        [Display(Name = "Data da Movimentação")]
        public DateTime? DataMovimentacao { get; set; }

        [Required]
        [AllowedValues("E", "S", ErrorMessage = "Selecione a Movimentação do produto entre Entradas ou Saídas")]
        [Display(Name = "Tipo de Movimentação")]
        public string? Tipo { get; set; }
    }
}
