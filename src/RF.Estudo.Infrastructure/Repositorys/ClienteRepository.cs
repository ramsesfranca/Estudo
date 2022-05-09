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
    public class ClienteRepository : BaseRepository<Guid, Cliente>, IClienteRepository
    {
        private readonly EstudoContext _contexto;

        public ClienteRepository(EstudoContext contexto)
            : base(contexto)
        {
            this._contexto = contexto;
        }

        public override async Task<IEnumerable<Cliente>> SelecionarTodos(params string[] propriedades)
        {
            var teste = await this._contexto.Set<Cliente>().AsNoTracking()
                                                      .Include("Telefones")
                                                      .OrderBy(p => p.Nome)
                                                      .ToListAsync();

            return teste;
        }

        public async Task<List<Cliente>> SelecionarTodosOrdenadoPeloNome()
        {
            return await this._contexto.Set<Cliente>().AsNoTracking()
                                                      .OrderBy(p => p.Nome)
                                                      .ToListAsync();
        }
    }
}
