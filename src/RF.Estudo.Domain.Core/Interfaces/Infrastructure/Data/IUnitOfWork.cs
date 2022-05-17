using System;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Core.Interfaces.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
    }
}
