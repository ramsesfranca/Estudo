using System;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Infrastructure.Contexts;

namespace RF.Estudo.Infrastructure.Repositorys
{
    public class CategoriaRepository : BaseRepository<Guid, Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(EstudoContext contexto)
            : base(contexto)
        {
        }
    }
}
