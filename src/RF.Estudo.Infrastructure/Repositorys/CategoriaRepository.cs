using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Infrastructure.Contexts;
using System;

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
