using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using System;

namespace RF.Estudo.Domain.Services
{
    public class ProdutoService : BaseService<Guid, Produto, IProdutoRepository>, IProdutoService
    {
        public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
        }
    }
}
