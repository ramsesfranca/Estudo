using Microsoft.Extensions.DependencyInjection;
using RF.Estudo.Application.Profiles;

namespace RF.Estudo.Infrastructure.CrossCutting.Mapper
{
    public static class MapperConfig
    {
        public static IServiceCollection AddMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProdutoProfile),
                typeof(CategoriaProfile));

            return services;
        }
    }
}
