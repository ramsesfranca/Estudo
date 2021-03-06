using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Data.Repositorys;
using RF.Estudo.Domain.DTOs;
using RF.Estudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Interfaces.Repositorys
{
    public interface IProdutoRepository : IBaseRepository<Guid, Produto>
    {
        Task<List<ProdutoDTO>> SelecionarTodosAtivos();
    }
}
