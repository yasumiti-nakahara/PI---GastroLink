using Microsoft.EntityFrameworkCore;

namespace GastroLink.Api.Data
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Entities.Usuario> Usuarios { get; set; }
        public DbSet<Entities.Restaurante> Restaurantes { get; set; }
        public DbSet<Entities.Influencer> Influencers { get; set; }
        public DbSet<Entities.Proposta> Propostas { get; set; }
        public DbSet<Entities.Parceria> Parcerias { get; set; }

    }
}
