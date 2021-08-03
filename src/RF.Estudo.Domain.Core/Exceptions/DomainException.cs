using System;

namespace RF.Estudo.Domain.Core.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string mensagem)
            : base(mensagem)
        {
        }
    }
}
