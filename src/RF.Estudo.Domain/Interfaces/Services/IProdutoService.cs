using RF.Estudo.Domain.Core.Interfaces.Service.Services;
using RF.Estudo.Domain.Entities;
using System;

namespace RF.Estudo.Domain.Interfaces.Services
{
    public interface IProdutoService : IBaseService<Guid, Produto>
    {
    }
}
