using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations {

    public class PessoaFisicaConfiguration : IEntityTypeConfiguration<PessoaFisica> {
        public void Configure (EntityTypeBuilder<PessoaFisica> builder) 
        {
            builder.HasKey (item => item.Id);

            builder.Property (item => item.Nome).HasMaxLength (155).IsRequired ();
            builder.Property (item => item.Email).HasMaxLength (155).IsRequired ();

            builder.HasIndex (item => item.Email).IsUnique ();

            builder.HasMany(item => item.Telefones)
                .WithOne(item => item.PessoaFisica)
                .HasForeignKey(item => item.IdPessoaFisica);

            builder.ToTable ("PessoasFisicas");
        }
    }
}
