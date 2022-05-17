using Microsoft.Extensions.DependencyInjection;

namespace RF.Estudo.Infrastructure.CrossCutting.Mediator
{
    public static class MediatorConfig
    {
        public static IServiceCollection AddMediatorConfig(this IServiceCollection services)
        {
            //services.AddMediatR(typeof(Startup));

            return services;
        }
    }
}
