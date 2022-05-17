using System;

namespace RF.Estudo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvent
    {
        public int QuantidadeRestante { get; private set; }

        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
