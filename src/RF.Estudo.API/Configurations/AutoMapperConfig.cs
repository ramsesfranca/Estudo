using Microsoft.Extensions.DependencyInjection;
using RF.Estudo.Application.Profiles;

namespace RF.Estudo.API.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProdutoProfile),
                typeof(CategoriaProfile));

            return services;
        }
    }
}
