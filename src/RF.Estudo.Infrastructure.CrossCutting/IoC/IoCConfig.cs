using Microsoft.Extensions.DependencyInjection;
using RF.Estudo.Application.Services;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Data;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Services;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using RF.Estudo.Domain.Services;
using RF.Estudo.Infrastructure.Contexts;
using RF.Estudo.Infrastructure.CrossCutting.Services;
using RF.Estudo.Infrastructure.Repositorys;

namespace RF.Estudo.Infrastructure.CrossCutting.IoC
{
    public static class IoCConfig
    {
        public static IServiceCollection AddServiceDependency(this IServiceCollection services)
        {
            #region Infrastructure

            services.AddScoped<EstudoContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            #endregion

            #region Domain Services

            services.AddScoped<IEstoqueService, EstoqueService>();

            #endregion

            #region Domain Events

            //services.AddScoped<IMediatorHandler, MediatorHandler>();
            //services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

            #endregion

            #region Application

            services.AddScoped<IProdutoApplicationService, ProdutoApplicationService>();
            services.AddScoped<ICategoriaApplicationService, CategoriaApplicationService>();

            #endregion

            return services;
        }
    }
}
