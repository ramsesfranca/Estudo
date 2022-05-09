using AutoMapper;
using RF.Estudo.Application.ViewModels.Produto;
using RF.Estudo.Domain.DTOs;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Enums;
using RF.Estudo.Domain.ValueObjects;

namespace RF.Estudo.Application.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            this.CreateMap<Produto, FormularioProdutoViewModel>()
                .ForMember(d => d.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
                .ForMember(d => d.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
                .ForMember(d => d.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));
            this.CreateMap<ProdutoDTO, ListaProdutoViewModel>();

            this.CreateMap<FormularioProdutoViewModel, Produto>()
                .ConstructUsing(p =>
                    new Produto(p.Nome,
                        p.Descricao,
                        p.Valor,
                        new Dimensoes(p.Altura, p.Largura, p.Profundidade),
                        TipoProduto.MateriaPrima,
                        p.Ativo,
                        p.CategoriaId));
        }
    }
}
