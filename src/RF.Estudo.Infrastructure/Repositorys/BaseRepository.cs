using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RF.Estudo.Infrastructure.Contexts;

namespace RF.Estudo.Infrastructure.Repositorys
{
    public abstract class BaseRepository<TId, TEntidade> : IBaseRepository<TId, TEntidade>
        where TId : IEquatable<TId>
        where TEntidade : BaseEntity<TId>
    {
        private readonly EstudoContext _contexto;
        private readonly DbSet<TEntidade> _entidade;

        protected BaseRepository(EstudoContext contexto)
        {
            this._contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
            this._entidade = contexto.Set<TEntidade>();
        }
        
        public virtual void Inserir(TEntidade entidade)
        {
            this._entidade.Add(entidade);
        }

        public virtual void Alterar(TEntidade entidade)
        {
            this._entidade.Update(entidade);
        }

        public virtual void Deletar(TEntidade entidade)
        {
            this._entidade.Remove(entidade);
        }

        public virtual async Task<TEntidade> SelecionarPorId(TId id, params string[] propriedades)
        {
            return await this._entidade.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntidade>> SelecionarTodos(params string[] propriedades)
        {
            return await this._entidade.ToListAsync();
        }

        public virtual async Task<bool> Existe(Expression<Func<TEntidade, bool>> predicado)
        {
            return await this._entidade.AnyAsync();
        }

        public virtual void Dispose()
        {
            this._contexto.Dispose();
            GC.SuppressFinalize(this);
        }

        ~BaseRepository()
        {
            this.Dispose();
        }
    }
}
