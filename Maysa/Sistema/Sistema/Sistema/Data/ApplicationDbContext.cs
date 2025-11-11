using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Sistema.Models;

namespace Sistema.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Material> Materiais { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
    }
}
