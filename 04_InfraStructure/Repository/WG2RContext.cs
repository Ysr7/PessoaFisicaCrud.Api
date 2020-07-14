using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Configurations;

namespace Repository {

      public class WG2RContext : DbContext
      {
            public WG2RContext (DbContextOptions<WG2RContext> options) : base (options) { }

            public DbSet<PessoaFisica> PessoaFisicas { get; set; }

            public DbSet<Telefone> Telefones { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder) 
            {
                  modelBuilder.ApplyConfiguration(new PessoaFisicaConfiguration());
                  modelBuilder.ApplyConfiguration(new TelefoneConfiguration());
            }
      }

}