using AutoMapper;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;

namespace RF.Estudo.Application.Profiles
{
    public class TelefoneProfile : Profile
    {
        public TelefoneProfile()
        {
            this.CreateMap<Telefone, TelefoneViewModel>().ReverseMap();
        }
    }
}
