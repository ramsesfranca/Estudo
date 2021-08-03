using RF.Estudo.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace RF.Estudo.Domain.Entities
{
    public class Categoria : BaseEntity<Guid>
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public virtual ICollection<Produto> Produtos { get; private set; }

        protected Categoria()
        {
        }

        public Categoria(string nome, string descricao)
        {
            this.Validar();

            this.Nome = nome;
            this.Descricao = descricao;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(this.Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeVazio(this.Descricao, "O campo Descrição da categoria não pode estar vazio");
        }
    }
}
