using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace RF.Estudo.Domain.Entities
{
    public class Pedido : BaseEntity<Guid>, IAggregateRoot
    {
        public virtual ICollection<PedidoItem> Pedidos { get; private set; }
    }
}
