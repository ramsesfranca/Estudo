using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;
using System;

namespace RF.Estudo.Infrastructure.Configurations
{
    public class ClienteConfiguration : BaseConfiguration<Guid, Cliente>
    {
        public override void Configure(EntityTypeBuilder<Cliente> builder)
        {
            base.Configure(builder);

            builder.ToTable("Clientes");

            builder.Property(c => c.Nome).HasMaxLength(250).IsUnicode(false).IsRequired();
            builder.Property(c => c.Rg).HasMaxLength(9).IsUnicode(false).IsRequired();
            builder.Property(c => c.Nascimento).IsRequired();
            builder.OwnsOne(c => c.Localizacao, cm =>
            {
                cm.Property(l => l.Endereco).HasColumnName("Endereco").HasMaxLength(250).IsUnicode(false).IsRequired();
                cm.Property(l => l.Bairro).HasColumnName("Bairro").HasMaxLength(250).IsUnicode(false).IsRequired();
                cm.Property(l => l.Cidade).HasColumnName("Cidade").HasMaxLength(250).IsUnicode(false).IsRequired();
                cm.Property(l => l.Cep).HasColumnName("Cep").HasMaxLength(10).IsUnicode(false).IsRequired();
            });

            // 1 : N => Telefones : Cliente
            builder.HasMany(c => c.Telefones).WithOne(t => t.Cliente).HasForeignKey(t => t.ClienteId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
