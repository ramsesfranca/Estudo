using RF.Estudo.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Core.Interfaces.Service.Services
{
    public interface IBaseService<in TId, TEntidade> : IDisposable
        where TId : IEquatable<TId>
        where TEntidade : BaseEntity<TId>
    {
        Task Inserir(TEntidade entidade);
        Task Alterar(TEntidade entidade);
        Task Deletar(TEntidade entidade);
        Task<TEntidade> SelecionarPorId(TId id, params string[] propriedades);
        Task<IEnumerable<TEntidade>> SelecionarTodos(params string[] propriedades);
        Task<bool> Existe(Expression<Func<TEntidade, bool>> predicado);
    }
}
