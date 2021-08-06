using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RF.Estudo.Domain.Core.DomainObjects;
using System;

namespace RF.Estudo.Infrastructure.Mappings
{
    public class BaseMapping<TId, TEntidade> : IEntityTypeConfiguration<TEntidade>
        where TEntidade : BaseEntity<TId>
        where TId : IEquatable<TId>
    {
        public virtual void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(d => d.Id).IsRequired();
            builder.Property(e => e.DataHoraCadastro).IsRequired();
            builder.Property(e => e.DataHoraModificado);
        }
    }
}
