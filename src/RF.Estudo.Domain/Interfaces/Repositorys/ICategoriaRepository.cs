using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Repositorys;
using RF.Estudo.Domain.Entities;
using System;

namespace RF.Estudo.Domain.Interfaces.Repositorys
{
    public interface ICategoriaRepository : IBaseRepository<Guid, Produto>
    {
    }
}
