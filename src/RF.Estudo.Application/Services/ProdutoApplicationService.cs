﻿using AutoMapper;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services
{
    public class ProdutoApplicationService : BaseApplicationService<Guid, Produto, ProdutoViewModel, IProdutoService>, IProdutoApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoService _produtoService;

        public ProdutoApplicationService(IMapper mapper, IProdutoService produtoService)
            : base(mapper, produtoService)
        {
            this._mapper = mapper;
            this._produtoService = produtoService;
        }

        public async Task<IEnumerable<ProdutoViewModel>> SelecionarTodosAtivos()
        {
            return this._mapper.Map<IEnumerable<ProdutoViewModel>>(await this._produtoService.SelecionarTodosAtivos());
        }
    }
}
