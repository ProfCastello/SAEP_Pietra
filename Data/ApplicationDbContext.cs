using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EstoqueEquipEletro.Models;

namespace EstoqueEquipEletro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EstoqueEquipEletro.Models.Produto> Produto { get; set; } = default!;

        public DbSet<EstoqueEquipEletro.Models.Produto> Movimentacao { get; set; } = default!;
        public DbSet<EstoqueEquipEletro.Models.Movimentacao> Movimentacao_1 { get; set; } = default!;
    }
}
