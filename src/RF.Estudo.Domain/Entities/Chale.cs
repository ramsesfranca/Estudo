using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace RF.Estudo.Domain.Entities
{
    public class Chale : BaseEntity<Guid>, IAggregateRoot
    {
        public string Localizacao { get; private set; }
        public int Capacidade { get; private set; }
        public decimal ValorAltaEstacao { get; private set; }
        public decimal ValorBaixaEstacao { get; private set; }

        public virtual ICollection<Item> Itens { get; private set; }
        public virtual ICollection<Hospedagem> Hospedagems { get; private set; }

        protected Chale()
        {
        }

        public Chale(string localizacao, int capacidade, decimal valorAltaEstacao, decimal valorBaixaEstacao, ICollection<Item> itens)
        {
            this.Localizacao = localizacao;
            this.Capacidade = capacidade;
            this.ValorAltaEstacao = valorAltaEstacao;
            this.ValorBaixaEstacao = valorBaixaEstacao;
            this.Itens = itens;
        }
    }
}
