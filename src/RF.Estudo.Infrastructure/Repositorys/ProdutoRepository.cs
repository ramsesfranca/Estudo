using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Infrastructure.Contexts;

namespace RF.Estudo.Infrastructure.Repositorys
{
    public class ProdutoRepository : BaseRepository<Guid, Produto>, IProdutoRepository
    {
        private readonly EstudoContext _contexto;

        public ProdutoRepository(EstudoContext contexto)
            : base(contexto)
        {
            this._contexto = contexto;
        }

        public async Task<IEnumerable<Produto>> SelecionarTodosAtivos()
        {
            var retorno = await this._contexto.Set<Produto>().AsNoTracking()
                .Where(p => p.Situacao)
                .OrderBy(p => p.Nome)
                .Select(p => new
                {
                    p.Nome,
                    p.Valor,
                    p.Quantidade
                }).ToListAsync();

            return null;
        }
    }
}
