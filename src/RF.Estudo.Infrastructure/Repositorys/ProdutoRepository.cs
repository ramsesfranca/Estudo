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
    public class ProdutoRepository : BaseRepository<Guid, Produto>, IProdutoRepository
    {
        private readonly EstudoContext _contexto;

        public ProdutoRepository(EstudoContext contexto)
            : base(contexto)
        {
            this._contexto = contexto;
        }

        public async Task<IEnumerable<ProdutoDTO2>> SelecionarTodosAtivos()
        {
            return await this._contexto.Set<Produto>().AsNoTracking()
                .Where(p => p.Situacao)
                .OrderBy(p => p.Nome)
                .Select(p => new ProdutoDTO2
                {
                    Nome = p.Nome,
                    Valor = p.Valor,
                    Quantidade = p.Quantidade
                }).ToListAsync();
        }
    }

    public class ProdutoDTO2
    {
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
    }
}
