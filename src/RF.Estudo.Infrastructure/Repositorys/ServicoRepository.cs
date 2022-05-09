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
    public class ServicoRepository : BaseRepository<Guid, Servico>, IServicoRepository
    {
        private readonly EstudoContext _contexto;

        public ServicoRepository(EstudoContext contexto)
            : base(contexto)
        {
            this._contexto = contexto;
        }

        public override async Task<IEnumerable<Servico>> SelecionarTodos(params string[] propriedades)
        {
            return await this._contexto.Set<Servico>().AsNoTracking()
                                                      .OrderBy(p => p.Nome)
                                                      .ToListAsync();
        }
    }
}
