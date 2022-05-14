using RF.Estudo.Application.ViewModels.Produto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services.Interfaces
{
    public interface IProdutoApplicationService : IBaseApplicationService<Guid, FormularioProdutoViewModel>
    {
        Task<List<ListaProdutoViewModel>> SelecionarTodosAtivos();
        Task<FormularioProdutoViewModel> DebitarEstoque(Guid id, int quantidade);
        Task<FormularioProdutoViewModel> ReporEstoque(Guid id, int quantidade);
    }
}
