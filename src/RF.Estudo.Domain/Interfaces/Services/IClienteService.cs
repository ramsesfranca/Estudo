using RF.Estudo.Domain.Core.Interfaces.Service.Services;
using RF.Estudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Interfaces.Services
{
    public interface IClienteService : IBaseService<Guid, Cliente>
    {
        Task<List<Cliente>> SelecionarTodosOrdenadoPeloNome();
    }
}
