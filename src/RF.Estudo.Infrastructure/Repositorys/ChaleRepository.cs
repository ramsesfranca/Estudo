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
    public class ChaleRepository : BaseRepository<Guid, Chale>, IChaleRepository
    {
        private readonly EstudoContext _contexto;

        public ChaleRepository(EstudoContext contexto)
            : base(contexto)
        {
            this._contexto = contexto;
        }

        public override async Task<IEnumerable<Chale>> SelecionarTodos(params string[] propriedades)
        {
            return await this._contexto.Set<Chale>().AsNoTracking()
                                                    .Include("Itens")
                                                    .OrderBy(p => p.Localizacao)
                                                    .ToListAsync();
        }
    }
}
