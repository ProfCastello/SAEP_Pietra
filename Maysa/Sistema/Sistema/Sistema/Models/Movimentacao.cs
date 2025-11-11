using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema.Models
{
    public class Movimentacao
    {
        public int MovimentacaoId { get; set; }

        // Relacionamento com Material
        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Display(Name = "Material")]
        public int MaterialId { get; set; }
        public Material? Material { get; set; }

        // Relacionamento com Tabela de Usuários (Identity Framework)
        public string? UsuarioId { get; set; }
        public IdentityUser? Usuario { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Digite uma quantidade válida.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [AllowedValues("E", "S", ErrorMessage = "O tipo deve ser 'E' para Entrada ou 'S' para Saída.")]
        [Display(Name = "Tipo de Movimentação")]
        public string? Tipo { get; set; } // "Entrada" ou "Saída"

        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida.")]
        [Display(Name = "Data de Movimentação")]
        public DateTime? DataMovimentacao { get; set; }
    }
}
