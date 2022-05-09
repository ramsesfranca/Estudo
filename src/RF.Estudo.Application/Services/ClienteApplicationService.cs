using AutoMapper;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services
{
    public class ClienteApplicationService : BaseApplicationService<Guid, Cliente, ClienteViewModel, IClienteService>, IClienteApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;

        public ClienteApplicationService(IMapper mapper, IClienteService clienteService)
            : base(mapper, clienteService)
        {
            this._mapper = mapper;
            this._clienteService = clienteService;
        }

        public async Task<List<ClienteViewModel>> SelecionarTodosOrdenadoPeloNome()
        {
            return this._mapper.Map<List<ClienteViewModel>>(await this._clienteService.SelecionarTodosOrdenadoPeloNome());
        }
    }
}
