using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;

namespace RF.Estudo.Infrastructure.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");

            builder.HasKey(i => i.Nome);

            builder.Property(i => i.Nome).HasMaxLength(80).IsUnicode(false).IsRequired();
            builder.Property(i => i.Descricao).HasMaxLength(250).IsUnicode(false).IsRequired();
        }
    }
}
