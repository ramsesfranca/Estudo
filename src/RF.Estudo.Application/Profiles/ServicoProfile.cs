using AutoMapper;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;

namespace RF.Estudo.Application.Profiles
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            this.CreateMap<Servico, ServicoViewModel>().ReverseMap();
        }
    }
}
