using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PessoasAptas.Core.Entities;

namespace PessoasAptas.Infrastructure.Persistence.Configurations
{
    public class CriterioConfigurations : IEntityTypeConfiguration<Criterio>
    {
        public void Configure(EntityTypeBuilder<Criterio> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .HasMany(u => u.PessoaCriterios)
                .WithOne()
                .HasForeignKey(u => u.IdCriterio);
        }
    }
}
