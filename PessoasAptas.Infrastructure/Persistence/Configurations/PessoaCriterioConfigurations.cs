using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PessoasAptas.Core.Entities;

namespace PessoasAptas.Infrastructure.Persistence.Configurations
{
    public class PessoaCriterioConfigurations : IEntityTypeConfiguration<PessoaCriterio>
    {
        public void Configure(EntityTypeBuilder<PessoaCriterio> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Pessoa)
                .WithMany(p => p.PessoaCriterios)
                .HasForeignKey(p => p.IdPessoa);

            builder
                .HasOne(p => p.Criterio)
                .WithMany(p => p.PessoaCriterios)
                .HasForeignKey(p => p.IdCriterio);
        }
    }
}
