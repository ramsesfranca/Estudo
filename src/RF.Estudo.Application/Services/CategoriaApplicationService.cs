using AutoMapper;
using RF.Estudo.Application.DTOs;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Services;
using System;

namespace RF.Estudo.Application.Services
{
    public class CategoriaApplicationService : BaseApplicationService<Guid, Categoria, CategoriaDTO, ICategoriaService>, ICategoriaApplicationService
    {
        public CategoriaApplicationService(IMapper mapper, ICategoriaService categoriaService)
            : base(mapper, categoriaService)
        {
        }
    }
}
