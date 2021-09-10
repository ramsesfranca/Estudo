using RF.Estudo.Domain.Core.Interfaces.Service.Services;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Projections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Interfaces.Services
{
    public interface IProdutoService : IBaseService<Guid, Produto>
    {
        Task<IEnumerable<ProdutoProjection>> SelecionarTodosAtivos();
    }
}
