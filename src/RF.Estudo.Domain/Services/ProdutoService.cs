using RF.Estudo.Domain.DTOs;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Services
{
    public class ProdutoService : BaseService<Guid, Produto, IProdutoRepository>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            this._produtoRepository = produtoRepository;
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
