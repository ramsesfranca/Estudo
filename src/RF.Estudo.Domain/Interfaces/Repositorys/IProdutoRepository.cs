using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Repositorys;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Projections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Interfaces.Repositorys
{
    public interface IProdutoRepository : IBaseRepository<Guid, Produto>
    {
        Task<IEnumerable<ProdutoProjection>> SelecionarTodosAtivos();
    }
}
