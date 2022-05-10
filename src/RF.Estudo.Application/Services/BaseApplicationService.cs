using AutoMapper;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces;
using RF.Estudo.Domain.Core.Interfaces.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services
{
    public abstract class BaseApplicationService<TId, TEntidade, TViewModel, TIBaseService> : IBaseApplicationService<TId, TViewModel>
        where TId : IEquatable<TId>
        where TEntidade : BaseEntity<TId>, IAggregateRoot
        where TViewModel : BaseViewModel
        where TIBaseService : IBaseService<TId, TEntidade>

    {
        private readonly IMapper _mapper;
        private readonly TIBaseService _baseService;

        protected BaseApplicationService(IMapper mapper, TIBaseService baseService)
        {
            this._mapper = mapper;
            this._baseService = baseService;
        }

        public virtual async Task Inserir(TViewModel modelo)
        {
            await this._baseService.Inserir(this._mapper.Map<TEntidade>(modelo));
        }

        public virtual async Task Alterar(TViewModel modelo)
        {
            await this._baseService.Alterar(this._mapper.Map<TEntidade>(modelo));
        }

        public virtual async Task Deletar(TViewModel modelo)
        {
            await this._baseService.Deletar(this._mapper.Map<TEntidade>(modelo));
        }

        public virtual async Task<TViewModel> SelecionarPorId(TId id, params string[] propriedades)
        {
            return this._mapper.Map<TViewModel>(await this._baseService.SelecionarPorId(id, propriedades));
        }

        public virtual async Task<IEnumerable<TViewModel>> SelecionarTodos(params string[] propriedades)
        {
            return this._mapper.Map<List<TViewModel>>(await this._baseService.SelecionarTodos(propriedades));
        }

        public virtual async Task<bool> Existe(Expression<Func<TViewModel, bool>> predicado)
        {
            return await this._baseService.Existe(this._mapper.Map<Expression<Func<TEntidade, bool>>>(predicado));
        }

        public void Dispose()
        {
            this._baseService?.Dispose();
        }
    }
}
