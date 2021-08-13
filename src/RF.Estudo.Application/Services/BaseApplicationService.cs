using AutoMapper;
using RF.Estudo.Application.DTOs;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Domain.Core.DomainObjects;
using RF.Estudo.Domain.Core.Interfaces.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services
{
    public abstract class BaseApplicationService<TId, TEntidade, TEntidadeDTO, TIBaseService> : IBaseApplicationService<TId, TEntidadeDTO>
        where TId : IEquatable<TId>
        where TEntidade : BaseEntity<TId>
        where TEntidadeDTO : BaseDTO<TId>
        where TIBaseService : IBaseService<TId, TEntidade>

    {
        private readonly IMapper _mapper;
        private readonly TIBaseService _baseService;

        protected BaseApplicationService(IMapper mapper, TIBaseService baseService)
        {
            this._mapper = mapper;
            this._baseService = baseService;
        }

        public virtual void Inserir(TEntidadeDTO entidade)
        {
            this._baseService.Inserir(this._mapper.Map<TEntidade>(entidade));
        }

        public virtual void Alterar(TEntidadeDTO entidade)
        {
            this._baseService.Alterar(this._mapper.Map<TEntidade>(entidade));
        }

        public virtual void Deletar(TEntidadeDTO entidade)
        {
            this._baseService.Deletar(this._mapper.Map<TEntidade>(entidade));
        }

        public virtual async Task<TEntidadeDTO> SelecionarPorId(TId id, params string[] propriedades)
        {
            return this._mapper.Map<TEntidadeDTO>(await this._baseService.SelecionarPorId(id, propriedades));
        }

        public virtual async Task<IEnumerable<TEntidadeDTO>> SelecionarTodos(params string[] propriedades)
        {
            return this._mapper.Map<List<TEntidadeDTO>>(await this._baseService.SelecionarTodos(propriedades));
        }

        public virtual async Task<bool> Existe(Expression<Func<TEntidadeDTO, bool>> predicado)
        {
            return await this._baseService.Existe(this._mapper.Map<Expression<Func<TEntidade, bool>>>(predicado));
        }

        public void Dispose()
        {
            this._baseService.Dispose();
        }
    }
}
