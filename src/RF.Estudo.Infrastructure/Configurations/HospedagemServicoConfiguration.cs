using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Entities;

namespace RF.Estudo.Infrastructure.Configurations
{
    public class HospedagemServicoConfiguration : IEntityTypeConfiguration<HospedagemServico>
    {
        public void Configure(EntityTypeBuilder<HospedagemServico> builder)
        {
            builder.ToTable("Hospedagem_Servico");

            builder.HasKey(t => t.DataServico);

            builder.Property(hs => hs.DataServico).HasDefaultValueSql("getdate()").IsRequired();
            builder.Property(hs => hs.ValorServico).HasPrecision(18, 2).IsRequired();
        }
    }
}
