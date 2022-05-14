using AutoMapper;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels.Categoria;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using System;

namespace RF.Estudo.Application.Services
{
    public class CategoriaApplicationService : BaseApplicationService<Guid, Categoria, FormularioCategoriaViewModel, ICategoriaRepository>, ICategoriaApplicationService
    {
        public CategoriaApplicationService(IMapper mapper, IUnitOfWork unitOfWork, ICategoriaRepository categoriaRepository)
            : base(mapper, unitOfWork, categoriaRepository)
        {
        }
    }
}
