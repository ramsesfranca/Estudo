using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Repositorys;
using RF.Estudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Interfaces.Repositorys
{
    public interface IClienteRepository : IBaseRepository<Guid, Cliente>
    {
        Task<List<Cliente>> SelecionarTodosOrdenadoPeloNome();
    }
}
