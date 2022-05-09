using AutoMapper;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;
using System.Collections.Generic;

namespace RF.Estudo.Application.Profiles
{
    public class HospedagemProfile : Profile
    {
        public HospedagemProfile()
        {
            this.CreateMap<Hospedagem, HospedagemViewModel>();

            this.CreateMap<HospedagemViewModel, Hospedagem>()
                .ConstructUsing((c, m) =>
                    new Hospedagem(c.ChaleId,
                        c.ClienteId,
                        c.Estado,
                        c.DataInicio,
                        c.DataFim,
                        c.QtdPessoas,
                        c.Desconto,
                        m.Mapper.Map<List<Servico>>(c.Servicos)));


            this.CreateMap<Servico, HospedagemServicoViewModel>().ReverseMap();
        }
    }
}
