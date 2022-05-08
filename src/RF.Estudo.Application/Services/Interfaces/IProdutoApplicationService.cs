using RF.Estudo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services.Interfaces
{
    public interface IProdutoApplicationService : IBaseApplicationService<Guid, ProdutoViewModel>
    {
        Task<IEnumerable<ProdutoViewModel>> SelecionarTodosAtivos();
    }
}
