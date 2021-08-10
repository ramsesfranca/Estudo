using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using System;

namespace RF.Estudo.Domain.Services
{
    public class CategoriaService : BaseService<Guid, Categoria, ICategoriaRepository>, ICategoriaService
    {
        public CategoriaService(ICategoriaRepository categoriaRepository)
            : base(categoriaRepository)
        {
        }
    }
}
