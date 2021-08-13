using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services.Interfaces
{
    public interface IBaseApplicationService<in TId, TEntidadeDTO> : IDisposable
        where TId : IEquatable<TId>
        where TEntidadeDTO : class
    {
        void Inserir(TEntidadeDTO entidade);
        void Alterar(TEntidadeDTO entidade);
        void Deletar(TEntidadeDTO entidade);
        Task<TEntidadeDTO> SelecionarPorId(TId id, params string[] propriedades);
        Task<IEnumerable<TEntidadeDTO>> SelecionarTodos(params string[] propriedades);
        Task<bool> Existe(Expression<Func<TEntidadeDTO, bool>> predicado);
    }
}
