using AutoMapper;
using RF.Estudo.Application.ViewModels;
using RF.Estudo.Domain.Entities;

namespace RF.Estudo.Application.Profiles
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile()
        {
            this.CreateMap<Servico, ServicoViewModel>();

            this.CreateMap<ServicoViewModel, Servico>()
                .ConstructUsing((c, _) =>
                    new Servico(c.Nome, c.Valor));
        }
    }
}
