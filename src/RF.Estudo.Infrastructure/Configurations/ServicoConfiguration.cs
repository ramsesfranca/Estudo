using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;
using System;

namespace RF.Estudo.Infrastructure.Configurations
{
    public class ServicoConfiguration : BaseConfiguration<Guid, Servico>
    {
        public override void Configure(EntityTypeBuilder<Servico> builder)
        {
            base.Configure(builder);

            builder.ToTable("Servicos");

            builder.Property(p => p.Nome).HasMaxLength(250).IsUnicode(false).IsRequired();
            builder.Property(p => p.Valor).HasPrecision(18, 2).IsRequired();
        }
    }
}
