using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace RF.Estudo.Domain.Entities
{
    public class Servico : BaseEntity<Guid>, IAggregateRoot
    {
        public string Nome { get; private set; }
        public decimal Valor { get; private set; }

        public virtual ICollection<Hospedagem> Hospedagems { get; private set; }

        protected Servico()
        {
        }

        public Servico(string nome, decimal valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }

        public void AlterarNome(string nome)
        {
            Validacoes.ValidarSeVazio(nome, "O campo Nome do Serviço não pode estar vazio");

            this.Nome = nome;
        }

        public void AlterarValor(decimal valor)
        {
            Validacoes.ValidarSeMenorQue(valor, 1, "O campo Valor do Serviço não pode se menor igual a 0");

            this.Valor = valor;
        }
    }
}
