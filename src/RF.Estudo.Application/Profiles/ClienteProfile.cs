using AutoMapper;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.ValueObjects;
using System.Collections.Generic;

namespace RF.Estudo.Application.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            this.CreateMap<Cliente, ClienteViewModel>()
                .ForMember(d => d.Endereco, o => o.MapFrom(s => s.Localizacao.Endereco))
                .ForMember(d => d.Bairro, o => o.MapFrom(s => s.Localizacao.Bairro))
                .ForMember(d => d.Cidade, o => o.MapFrom(s => s.Localizacao.Cidade))
                .ForMember(d => d.Cep, o => o.MapFrom(s => s.Localizacao.Cep));

            this.CreateMap<ClienteViewModel, Cliente>()
                .ConstructUsing((c, m) =>
                    new Cliente(c.Nome,
                        c.Rg,
                        new Localizacao(c.Endereco, c.Bairro, c.Cidade, c.Cep),
                        c.Nascimento,
                        m.Mapper.Map<List<Telefone>>(c.Telefones)));

            this.CreateMap<Telefone, TelefoneViewModel>().ReverseMap();
        }
    }
}
