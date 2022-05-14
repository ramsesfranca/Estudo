using System;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Interfaces.Services
{
    public interface IEstoqueService
    {
        Task<bool> DebitarEstoque(Guid produtoId, int quantidade);
        Task<bool> ReporEstoque(Guid produtoId, int quantidade);
    }
}
