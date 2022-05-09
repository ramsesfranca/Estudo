using FluentValidation;
using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
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
        where TEntidade : BaseEntity<TId>, IAggregateRoot
        where TBaseRepository : IBaseRepository<TId, TEntidade>
    {
        private readonly TBaseRepository _baseRepository;
        private readonly IUnitOfWork _unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork,
            TBaseRepository baseRepository)
        {
            this._unitOfWork = unitOfWork;
            this._baseRepository = baseRepository;
        }

        public virtual async Task Inserir(TEntidade entidade)
        {
            this._baseRepository.Inserir(entidade);
            await this._unitOfWork.Commit();
        }

        public virtual async Task Alterar(TEntidade entidade)
        {
            this._baseRepository.Alterar(entidade);
            await this._unitOfWork.Commit();
        }

        public virtual async Task Deletar(TEntidade entidade)
        {
            this._baseRepository.Deletar(entidade);
            await this._unitOfWork.Commit();
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

        protected bool ExecutarValidacao<TValidacao>(TValidacao validacao, TEntidade entidade)
            where TValidacao : AbstractValidator<TEntidade>
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid)
            {
                return true;
            }

            //Notificar(validator);

            return false;
        }

        public void Dispose()
        {
            this._unitOfWork?.Dispose();
            this._baseRepository?.Dispose();
        }
    }
}
