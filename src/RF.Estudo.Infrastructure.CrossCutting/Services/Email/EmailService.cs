using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Services;

namespace RF.Estudo.Infrastructure.CrossCutting.Services
{
    public class EmailService : IEmailService
    {
        public bool Enviar(string para, string sujeito, string corpo)
        {
            // Enviar e-mail
            return true;
        }

    }
}
