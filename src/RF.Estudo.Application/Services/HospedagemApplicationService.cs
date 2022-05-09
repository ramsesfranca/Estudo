using AutoMapper;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Services;
using System;

namespace RF.Estudo.Application.Services
{
    public class HospedagemApplicationService : BaseApplicationService<Guid, Hospedagem, HospedagemViewModel, IHospedagemService>, IHospedagemApplicationService
    {
        public HospedagemApplicationService(IMapper mapper, IHospedagemService baseService)
            : base(mapper, baseService)
        {
        }
    }
}
