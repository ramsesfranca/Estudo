using System;

namespace RF.Estudo.Domain.Entities
{
    public class HospedagemServico
    {
        public Guid HospedagemId { get; private set; }
        public Guid ServicoId { get; private set; }
        public DateTime DataServico { get; private set; }
        public decimal ValorServico { get; private set; }

        public virtual Hospedagem Hospedagem { get; private set; }
        public virtual Servico Servico { get; private set; }

        protected HospedagemServico()
        {
        }

        public HospedagemServico(Guid hospedagemId, Guid servicoId)
        {
            this.HospedagemId = hospedagemId;
            this.ServicoId = servicoId;
        }
    }
}
