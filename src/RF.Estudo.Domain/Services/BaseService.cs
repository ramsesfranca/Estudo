using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Repositorys;
using RF.Estudo.Domain.Core.Interfaces.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Services
{
    public abstract class BaseService<TId, TEntidade, TBaseRepository> : IBaseService<TId, TEntidade>
        where TId : IEquatable<TId>
        where TEntidade : BaseEntity<TId>
        where TBaseRepository : IBaseRepository<TId, TEntidade>
    {
        private readonly TBaseRepository _baseRepository;

        protected BaseService(TBaseRepository baseRepository)
        {
            this._baseRepository = baseRepository;
        }

        public virtual void Inserir(TEntidade entidade)
        {
            this._baseRepository.Inserir(entidade);
        }

        public virtual void Alterar(TEntidade entidade)
        {
            this._baseRepository.Alterar(entidade);
        }

        public virtual void Deletar(TEntidade entidade)
        {
            this._baseRepository.Deletar(entidade);
        }

        public virtual async Task<TEntidade> SelecionarPorId(TId id, params string[] propriedades)
        {
            return await this._baseRepository.SelecionarPorId(id, propriedades);
        }

        public virtual async Task<IEnumerable<TEntidade>> SelecionarTodos(params string[] propriedades)
        {
            return await this._baseRepository.SelecionarTodos(propriedades);
        }

        public virtual async Task<bool> Existe(Expression<Func<TEntidade, bool>> predicado)
        {
            return await this._baseRepository.Existe(predicado);
        }

        public void Dispose()
        {
            this._baseRepository.Dispose();
        }
    }
}
