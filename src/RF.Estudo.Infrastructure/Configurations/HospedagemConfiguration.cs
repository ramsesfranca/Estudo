using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;
using System;

namespace RF.Estudo.Infrastructure.Configurations
{
    public class HospedagemConfiguration : BaseConfiguration<Guid, Hospedagem>
    {
        public override void Configure(EntityTypeBuilder<Hospedagem> builder)
        {
            base.Configure(builder);

            builder.ToTable("Hospedagens");

            builder.Property(h => h.Estado).IsRequired();
            builder.Property(h => h.DataInicio).IsRequired();
            builder.Property(h => h.DataFim).IsRequired();
            builder.Property(h => h.QtdPessoas).IsRequired();
            builder.Property(h => h.Desconto).IsRequired();
            builder.Property(h => h.ValorFinal).HasPrecision(18, 2).IsRequired();

            // N : N => Hospedagem : Servico
            builder.HasMany(x => x.Servicos)
                .WithMany(x => x.Hospedagems)
                .UsingEntity<HospedagemServico>(x => x.HasOne(y => y.Servico).WithMany().HasForeignKey(x => x.ServicoId),
                    x => x.HasOne(y => y.Hospedagem).WithMany().HasForeignKey(x => x.HospedagemId));
        }
    }
}
