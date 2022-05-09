using Microsoft.EntityFrameworkCore;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RF.Estudo.Infrastructure.Repositorys
{
    public class HospedagemRepository : BaseRepository<Guid, Hospedagem>, IHospedagemRepository
    {
        private readonly EstudoContext _contexto;

        public HospedagemRepository(EstudoContext contexto)
            : base(contexto)
        {
            this._contexto = contexto;
        }

        public override async Task<IEnumerable<Hospedagem>> SelecionarTodos(params string[] propriedades)
        {
            return await this._contexto.Set<Hospedagem>().AsNoTracking()
                                                         .Include("Servicos")
                                                         .OrderBy(h => h.DataInicio)
                                                         .ToListAsync();
        }
    }
}
