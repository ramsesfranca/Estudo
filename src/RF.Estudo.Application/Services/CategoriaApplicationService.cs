using AutoMapper;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels.Categoria;
using RF.Estudo.Domain.Core.Exceptions;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using System;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services
{
    public class CategoriaApplicationService : BaseApplicationService<Guid, Categoria, FormularioCategoriaViewModel, ICategoriaRepository>, ICategoriaApplicationService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaApplicationService(IMapper mapper, IUnitOfWork unitOfWork, ICategoriaRepository categoriaRepository)
            : base(mapper, unitOfWork, categoriaRepository)
        {
            this._mapper = mapper;
            this._categoriaRepository = categoriaRepository;
        }

        public override async Task Inserir(FormularioCategoriaViewModel modelo)
        {
            var categoria = this._mapper.Map<Categoria>(modelo);

            if (await this._categoriaRepository.Existe(c => c.Nome == categoria.Nome))
            {
                throw new DomainException("Já existe uma Categoria com este nome informado.");
            }

            this._categoriaRepository.Inserir(categoria);
        }
    }
}
