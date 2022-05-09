using AutoMapper;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;
using System.Collections.Generic;

namespace RF.Estudo.Application.Profiles
{
    public class ChaleProfile : Profile
    {
        public ChaleProfile()
        {
            this.CreateMap<Chale, ChaleViewModel>();

            this.CreateMap<ChaleViewModel, Chale>()
                .ConstructUsing((c, m) =>
                    new Chale(c.Localizacao,
                        c.Capacidade,
                        c.ValorAltaEstacao,
                        c.ValorBaixaEstacao,
                        m.Mapper.Map<List<Item>>(c.Itens)));

            this.CreateMap<Item, ItemViewModel>().ReverseMap();
        }
    }
}
