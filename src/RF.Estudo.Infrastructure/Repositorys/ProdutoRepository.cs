using Microsoft.EntityFrameworkCore;
using RF.Estudo.Domain.DTOs;
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

        public async Task<List<ProdutoDTO>> SelecionarTodosAtivos()
        {
            return await this._contexto.Set<Produto>().AsNoTracking()
                                                      .Where(p => p.Ativo)
                                                      .OrderBy(p => p.Nome)
                                                      .Select(p => new ProdutoDTO
                                                      {
                                                          Nome = p.Nome,
                                                          Valor = p.Valor,
                                                          Quantidade = p.Quantidade
                                                      }).ToListAsync();
        }
    }
}
