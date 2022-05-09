using System;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Core.Interfaces.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
