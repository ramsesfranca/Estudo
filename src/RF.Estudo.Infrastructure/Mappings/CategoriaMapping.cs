using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;
using System;

namespace RF.Estudo.Infrastructure.Mappings
{
    public class CategoriaMapping : BaseMapping<Guid, Categoria>
    {
        public override void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categorias");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome).HasMaxLength(250).IsUnicode(false).IsRequired();
            builder.Property(c => c.Descricao).HasMaxLength(500).IsUnicode(false).IsRequired();

            // 1 : N => Categorias : Produtos
            builder.HasMany(c => c.Produtos).WithOne(p => p.Categoria).HasForeignKey(p => p.CategoriaId);
        }
    }
}
