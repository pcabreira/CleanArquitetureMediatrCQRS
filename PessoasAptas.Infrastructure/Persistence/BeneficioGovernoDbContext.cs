using Microsoft.EntityFrameworkCore;
using PessoasAptas.Core.Entities;
using System.Reflection;

namespace PessoasAptas.Infrastructure.Persistence
{
    public class BeneficioGovernoDbContext : DbContext
    {
        public BeneficioGovernoDbContext(DbContextOptions<BeneficioGovernoDbContext> options) : base(options)
        {
            
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Criterio> Criterios { get; set; }
        public DbSet<PessoaCriterio> PessoaCriterios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
