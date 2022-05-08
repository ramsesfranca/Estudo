using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Exceptions;
using RF.Estudo.Domain.Enums;
using RF.Estudo.Domain.ValueObjects;
using System;

namespace RF.Estudo.Domain.Entities
{
    public class Produto : BaseEntity<Guid>
    {
        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
        public int Quantidade { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public TipoProduto TipoProduto { get; private set; }
        public bool Ativo { get; private set; }

        public virtual Categoria Categoria { get; private set; }

        protected Produto()
        {
        }

        public Produto(string nome, string descricao, decimal valor, Dimensoes dimensoes, TipoProduto tipoProduto, bool ativo, Guid CategoriaId)
        {
            this.Nome = nome;
            this.Descricao = descricao;
            this.Valor = valor;
            this.Dimensoes = dimensoes;
            this.TipoProduto = tipoProduto;
            this.Ativo = ativo;
            this.CategoriaId = CategoriaId;

            this.Validar();
        }

        public void AlterarCategoria(Categoria categoria)
        {
            this.Categoria = categoria;
            this.CategoriaId = categoria.Id;
        }

        public void Ativar() => this.Ativo = true;

        public void Desativar() => this.Ativo = false;

        public void ReporEstoque(int quantidade)
        {
            this.Quantidade += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return this.Quantidade >= quantidade;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0)
            {
                quantidade *= -1;
            }

            if (!this.PossuiEstoque(quantidade))
            {
                throw new DomainException("Estoque insuficiente");
            }

            this.Quantidade -= quantidade;
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(this.Nome, "O campo Nome do produto não pode estar vazio");
            Validacoes.ValidarSeVazio(this.Descricao, "O campo Descricao do produto não pode estar vazio");
            Validacoes.ValidarSeMenorQue(this.Valor, 1, "O campo Valor do produto não pode se menor igual a 0");
            Validacoes.ValidarSeIgual(this.CategoriaId, string.Empty, "A Categoria do produto não pode estar vazio");
        }
    }
}
