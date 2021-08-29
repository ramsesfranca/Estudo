using RF.Estudo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services.Interfaces
{
    public interface IProdutoApplicationService : IBaseApplicationService<Guid, ProdutoDTO>
    {
        Task<IEnumerable<ProdutoDTO>> SelecionarTodosAtivos();
    }
}
