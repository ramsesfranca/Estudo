using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;

namespace RF.Estudo.Infrastructure.Configurations
{
    public class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefones");

            builder.HasKey(t => t.Numero);

            builder.Property(t => t.Numero).HasMaxLength(20).IsUnicode(false).IsRequired();
            builder.Property(t => t.TipoTelefone).HasMaxLength(9).IsUnicode(false).IsRequired();
        }
    }
}
