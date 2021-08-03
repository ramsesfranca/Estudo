using System;

namespace RF.Estudo.Domain.Core.DomainObjects
{
    public abstract class BaseEntity<TId>
        where TId : IEquatable<TId>
    {
        public TId Id { get; set; }
        public DateTime DataHoraCadastro { get; set; }
        public DateTime? DataHoraModificado { get; set; }
    }
}
