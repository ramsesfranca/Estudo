using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.DTOs;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using RF.Estudo.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Services
{
    public class ProdutoService : BaseService<Guid, Produto, IProdutoRepository>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IUnitOfWork unitOfWork,
            IProdutoRepository produtoRepository) : base(unitOfWork, produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public override async Task Inserir(Produto entidade)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), entidade))
            {
                return;
            }

            if (await this._produtoRepository.Existe(p => p.Nome == entidade.Nome))
            {
                //Notificar("Já existe um Produto com este nome infomado.");
                return;
            }

            await base.Inserir(entidade);
        }

        public override async Task Alterar(Produto entidade)
        {
            var produto = await this.SelecionarPorId(entidade.Id);

            if (produto != null)
            {
                if (!ExecutarValidacao(new ProdutoValidation(), entidade))
                {
                    return;
                }

                if (await this._produtoRepository.Existe(p => p.Nome == entidade.Nome &&
                                                              p.Id != entidade.Id))
                {
                    //Notificar("Já existe um Produto com este nome infomado.");
                    return;
                }

                produto.AlterarNome(entidade.Nome);
                produto.AlterarDescricao(entidade.Descricao);

                await base.Alterar(produto);
            }
        }

        public override async Task Deletar(Produto entidade)
        {
            var produto = await this.SelecionarPorId(entidade.Id);

            if (produto != null)
            {
                await base.Deletar(produto);
            }
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await this._produtoRepository.SelecionarPorId(produtoId);

            if (produto == null)
            {
                return false;
            }

            if (!produto.PossuiEstoque(quantidade))
            {
                return false;
            }

            produto.DebitarEstoque(quantidade);

            // TODO: Parametrizar a quantidade de estoque baixo
            if (produto.Quantidade < 10)
            {
                //await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.Quantidade));
            }

            this._produtoRepository.Alterar(produto);

            return true;
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await this._produtoRepository.SelecionarPorId(produtoId);

            if (produto == null)
            {
                return false;
            }

            produto.ReporEstoque(quantidade);

            this._produtoRepository.Alterar(produto);

            return true;
        }

        public async Task<List<ProdutoDTO>> SelecionarTodosAtivos()
        {
            return await this._produtoRepository.SelecionarTodosAtivos();
        }
    }
}
