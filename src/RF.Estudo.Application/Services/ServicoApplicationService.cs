using AutoMapper;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Services;
using System;

namespace RF.Estudo.Application.Services
{
    public class ServicoApplicationService : BaseApplicationService<Guid, Servico, ServicoViewModel, IServicoService>, IServicoApplicationService
    {
        public ServicoApplicationService(IMapper mapper, IServicoService servicoService)
            : base(mapper, servicoService)
        {
        }
    }
}
