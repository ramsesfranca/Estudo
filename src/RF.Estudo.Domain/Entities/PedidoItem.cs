using RF.Estudo.Domain.Core.DomainObjects;
using System;

namespace RF.Estudo.Domain.Entities
{
    public class PedidoItem : BaseEntity<Guid>
    {
        public Guid PedidoId { get; private set; }
    }
}
