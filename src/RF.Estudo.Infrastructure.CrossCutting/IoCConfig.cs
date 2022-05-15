using Microsoft.Extensions.DependencyInjection;
using RF.Estudo.Application.Services;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using RF.Estudo.Domain.Services;
using RF.Estudo.Infrastructure.Contexts;
using RF.Estudo.Infrastructure.Repositorys;

namespace RF.Estudo.Infrastructure.CrossCutting
{
    public static class IoCConfig
    {
        public static IServiceCollection AddServiceDependency(this IServiceCollection services)
        {
            // Data
            services.AddScoped<EstudoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            // Services
            services.AddScoped<IEstoqueService, EstoqueService>();

            // Application
            services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
            services.AddScoped<ICategoriaApplicationService, CategoriaApplicationService>();

            return services;
        }
    }
}
