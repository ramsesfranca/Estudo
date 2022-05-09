using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;
using System;

namespace RF.Estudo.Infrastructure.Configurations
{
    public class ChaleConfiguration : BaseConfiguration<Guid, Chale>
    {
        public override void Configure(EntityTypeBuilder<Chale> builder)
        {
            base.Configure(builder);

            builder.ToTable("Chales");

            builder.Property(c => c.Localizacao).HasMaxLength(250).IsUnicode(false).IsRequired();
            builder.Property(c => c.Capacidade).IsRequired();
            builder.Property(c => c.ValorAltaEstacao).HasPrecision(18, 2).IsRequired();
            builder.Property(c => c.ValorBaixaEstacao).HasPrecision(18, 2).IsRequired();

            // N : N => Itens : Chales
            builder.HasMany(c => c.Itens).WithMany(t => t.Chales);
        }
    }
}
