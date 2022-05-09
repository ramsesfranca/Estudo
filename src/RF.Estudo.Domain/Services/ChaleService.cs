using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using System;

namespace RF.Estudo.Domain.Services
{
    public class ChaleService : BaseService<Guid, Chale, IChaleRepository>, IChaleService
    {
        public ChaleService(IUnitOfWork unitOfWork, IChaleRepository chaleRepository)
            : base(unitOfWork, chaleRepository)
        {
        }
    }
}
