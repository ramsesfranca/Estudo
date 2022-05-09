using AutoMapper;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Services;
using System;

namespace RF.Estudo.Application.Services
{
    public class ChaleApplicationService : BaseApplicationService<Guid, Chale, ChaleViewModel, IChaleService>, IChaleApplicationService
    {
        public ChaleApplicationService(IMapper mapper, IChaleService baseService)
            : base(mapper, baseService)
        {
        }
    }
}
