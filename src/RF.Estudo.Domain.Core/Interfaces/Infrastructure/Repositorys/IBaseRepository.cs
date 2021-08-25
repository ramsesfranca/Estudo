using RF.Estudo.Domain.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Core.Interfaces.Infrastructure.Repositorys
{
    public interface IBaseRepository<in TId, TEntidade> : IDisposable
        where TId : IEquatable<TId>
        where TEntidade : BaseEntity<TId>
    {
        void Inserir(TEntidade entidade);
        void Alterar(TEntidade entidade);
        void Deletar(TEntidade entidade);
        Task<TEntidade> SelecionarPorId(TId id, params string[] propriedades);
        Task<IEnumerable<TEntidade>> SelecionarTodos(params string[] propriedades);
        Task<bool> Existe(Expression<Func<TEntidade, bool>> predicado);
    }
}
