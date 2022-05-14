using AutoMapper;
using RF.Estudo.Application.ViewModels.Categoria;
using RF.Estudo.Domain.Entities;

namespace RF.Estudo.Application.Profiles
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            this.CreateMap<Categoria, FormularioCategoriaViewModel>();

            this.CreateMap<FormularioCategoriaViewModel, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Descricao));
        }
    }
}
