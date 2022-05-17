namespace RF.Estudo.Domain.Core.Interfaces.Infrastructure.Services
{
    public interface IEmailService
    {
        bool Enviar(string para, string sujeito, string corpo);
    }
}
