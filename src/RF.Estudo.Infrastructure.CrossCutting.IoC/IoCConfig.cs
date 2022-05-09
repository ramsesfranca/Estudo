using Microsoft.Extensions.DependencyInjection;
using RF.Estudo.Application.Services;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using RF.Estudo.Domain.Services;
using RF.Estudo.Infrastructure.Contexts;
using RF.Estudo.Infrastructure.Repositorys;

namespace RF.Estudo.Infrastructure.CrossCutting.IoC
{
    public static class IoCConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Data
            services.AddScoped<EstudoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            // Services
            services.AddScoped<IClienteService, ClienteService>();

            // Application
            services.AddScoped<IClienteApplicationService, ClienteApplicationService>();

            return services;
        }
    }
}
