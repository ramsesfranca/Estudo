using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces;
using RF.Estudo.Domain.Enums;
using System;
using System.Collections.Generic;

namespace RF.Estudo.Domain.Entities
{
    public class Hospedagem : BaseEntity<Guid>, IAggregateRoot
    {
        public Guid ChaleId { get; private set; }
        public Guid ClienteId { get; private set; }
        public Estado Estado { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }
        public int QtdPessoas { get; private set; }
        public int Desconto { get; private set; }
        public decimal ValorFinal { get; private set; }

        public virtual Chale Chale { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public virtual ICollection<Servico> Servicos { get; private set; }

        protected Hospedagem()
        {
        }

        public Hospedagem(Guid chaleId, Guid clienteId, Estado estado, DateTime dataInicio, DateTime dataFim, int qtdPessoas, int desconto, ICollection<Servico> servicos)
        {
            this.ChaleId = chaleId;
            this.ClienteId = clienteId;
            this.Estado = estado;
            this.DataInicio = dataInicio;
            this.DataFim = dataFim;
            this.QtdPessoas = qtdPessoas;
            this.Desconto = desconto;
            this.Servicos = servicos;
        }

        public void AtualizarServico(List<Servico> servicos)
        {
            this.Servicos = servicos;
        }
    }
}
