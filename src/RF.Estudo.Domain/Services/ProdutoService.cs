using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using RF.Estudo.Domain.Projections;
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

        public async Task<IEnumerable<ProdutoProjection>> SelecionarTodosAtivos()
        {
            return await this._produtoRepository.SelecionarTodosAtivos();
        }
    }
}
