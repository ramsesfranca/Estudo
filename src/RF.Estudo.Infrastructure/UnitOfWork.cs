using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Infrastructure.Contexts;
using System;
using System.Threading.Tasks;

namespace RF.Estudo.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EstudoContext _contexto;

        public UnitOfWork(EstudoContext contexto)
        {
            this._contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        }

        public async Task Commit()
        {
            await this._contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this._contexto.Dispose();
                }

                this._disposed = true;
            }
        }

        ~UnitOfWork()
        {
            this.Dispose(false);
        }

        private bool _disposed;
    }
}
