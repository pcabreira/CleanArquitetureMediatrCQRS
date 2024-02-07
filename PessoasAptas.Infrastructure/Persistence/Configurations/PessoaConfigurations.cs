using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PessoasAptas.Core.Entities;

namespace PessoasAptas.Infrastructure.Persistence.Configurations
{
    public class PessoaConfigurations : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(u => u.PessoaCriterios)
                .WithOne()
                .HasForeignKey(u => u.IdPessoa);
        }
    }
}
