using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces;
using RF.Estudo.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace RF.Estudo.Domain.Entities
{
    public class Cliente : BaseEntity<Guid>, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Rg { get; private set; }
        public DateTime Nascimento { get; private set; }
        public Localizacao Localizacao { get; private set; }

        public virtual ICollection<Telefone> Telefones { get; private set; }

        protected Cliente()
        {
        }

        public Cliente(string nome, string rg, Localizacao localizacao, DateTime nascimento, ICollection<Telefone> telefones)
        {
            this.Nome = nome;
            this.Rg = rg;
            this.Localizacao = localizacao;
            this.Nascimento = nascimento;
            this.Telefones = telefones;

            this.Validar();
        }

        public void AlterarNome(string nome)
        {
            Validacoes.ValidarSeVazio(nome, "O campo Nome do cliente não pode estar vazio");

            this.Nome = nome;
        }

        public void AlterarRg(string rg)
        {
            Validacoes.ValidarSeVazio(rg, "O campo RG do cliente não pode estar vazio");

            this.Rg = rg;
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(this.Nome, "O campo Nome do cliente não pode estar vazio");
            Validacoes.ValidarSeVazio(this.Rg, "O campo Rg do cliente não pode estar vazio");
        }
    }
}
