using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RF.Estudo.Infrastructure.Repositorys
{
    public abstract class BaseRepository<TId, TEntidade> : IBaseRepository<TId, TEntidade>
        where TId : IEquatable<TId>
        where TEntidade : BaseEntity<TId>
    {
        public void Inserir(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Alterar(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(TEntidade entidade)
        {
            throw new NotImplementedException();
        }

        public Task<TEntidade> SelecionarPorId(TId id, params string[] propriedades)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntidade>> SelecionarTodos(params string[] propriedades)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Existe(Expression<Func<TEntidade, bool>> predicado)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
