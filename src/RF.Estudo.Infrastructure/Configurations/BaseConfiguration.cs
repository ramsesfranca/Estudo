using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Core.DomainObjects;
using System;

namespace RF.Estudo.Infrastructure.Configurations
{
    public class BaseConfiguration<TId, TEntidade> : IEntityTypeConfiguration<TEntidade>
        where TEntidade : BaseEntity<TId>
        where TId : IEquatable<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasDefaultValueSql("NEWID()").IsRequired();
            builder.Property(e => e.DataHoraCadastro).IsRequired();
            builder.Property(e => e.DataHoraModificado);
        }
    }
}
