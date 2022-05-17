using System;

namespace RF.Estudo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvent //: DomainEvent
    {
        public int QuantidadeRestante { get; }

        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) //: base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
