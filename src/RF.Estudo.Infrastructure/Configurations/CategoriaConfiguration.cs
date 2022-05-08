using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;
using System;

namespace RF.Estudo.Infrastructure.Configurations
{
    public class CategoriaConfiguration : BaseConfiguration<Guid, Categoria>
    {
        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            base.Configure(builder);

            builder.ToTable("Categorias");

            builder.Property(c => c.Nome).HasMaxLength(250).IsUnicode(false).IsRequired();
            builder.Property(c => c.Descricao).HasMaxLength(500).IsUnicode(false).IsRequired();

            // 1 : N => Categorias : Produtos
            builder.HasMany(c => c.Produtos).WithOne(p => p.Categoria).HasForeignKey(p => p.CategoriaId);
        }
    }
}
