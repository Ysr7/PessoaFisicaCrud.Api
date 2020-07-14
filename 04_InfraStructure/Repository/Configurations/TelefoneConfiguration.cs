using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{

    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(item => item.Id);

            builder.Property(item => item.Numero).HasMaxLength(15).IsRequired();
            builder.Property(item => item.DDD).HasMaxLength(2).IsRequired();

            builder.ToTable("Telefones");
        }
    }

}

