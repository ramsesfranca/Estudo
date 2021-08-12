using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;
using System;

namespace RF.Estudo.Infrastructure.Mappings
{
    public class ProdutoMapping : BaseMapping<Guid, Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.ToTable("Produtos");

            builder.Property(p => p.Nome).HasMaxLength(250).IsUnicode(false).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(500).IsUnicode(false).IsRequired();
            builder.OwnsOne(p => p.Dimensoes, cm =>
            {
                cm.Property(d => d.Altura).HasColumnName("Altura").HasColumnType("int");
                cm.Property(d => d.Largura).HasColumnName("Largura").HasColumnType("int");
                cm.Property(d => d.Profundidade).HasColumnName("Profundidade").HasColumnType("int");
            });
        }
    }
}
