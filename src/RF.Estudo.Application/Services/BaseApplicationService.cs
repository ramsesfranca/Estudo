using AutoMapper;
using FluentValidation;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Repositorys;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services
{
    public abstract class BaseApplicationService<TId, TEntidade, TViewModel, TBaseRepository> : IBaseApplicationService<TId, TViewModel>
        where TId : IEquatable<TId>
        where TEntidade : BaseEntity<TId>, IAggregateRoot
        where TViewModel : BaseViewModel
        where TBaseRepository : IBaseRepository<TId, TEntidade>

    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly TBaseRepository _baseRepository;

        protected BaseApplicationService(IMapper mapper, IUnitOfWork unitOfWork, TBaseRepository baseRepository)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._baseRepository = baseRepository;
        }

        public virtual async Task Inserir(TViewModel modelo)
        {
            this._baseRepository.Inserir(this._mapper.Map<TEntidade>(modelo));
            await this._unitOfWork.Commit();
        }

        public virtual async Task Alterar(TViewModel modelo)
        {
            this._baseRepository.Alterar(this._mapper.Map<TEntidade>(modelo));
            await this._unitOfWork.Commit();
        }

        public virtual async Task Deletar(TViewModel modelo)
        {
            this._baseRepository.Deletar(this._mapper.Map<TEntidade>(modelo));
            await this._unitOfWork.Commit();
        }

        public virtual async Task<TViewModel> SelecionarPorId(TId id, params string[] propriedades)
        {
            return this._mapper.Map<TViewModel>(await this._baseRepository.SelecionarPorId(id, propriedades));
        }

        public virtual async Task<IEnumerable<TViewModel>> SelecionarTodos(params string[] propriedades)
        {
            return this._mapper.Map<List<TViewModel>>(await this._baseRepository.SelecionarTodos(propriedades));
        }

        public virtual async Task<bool> Existe(Expression<Func<TViewModel, bool>> predicado)
        {
            return await this._baseRepository.Existe(this._mapper.Map<Expression<Func<TEntidade, bool>>>(predicado));
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
            this._baseRepository?.Dispose();
        }
    }
}
