using AutoMapper;
using RF.Estudo.Application.DTOs;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Services;
using System;

namespace RF.Estudo.Application.Services
{
    public class ProdutoApplicationService : BaseApplicationService<Guid, Produto, ProdutoDTO, IProdutoService>, IProdutoApplicationService
    {
        public ProdutoApplicationService(IMapper mapper, IProdutoService produtoService)
            : base(mapper, produtoService)
        {
        }
    }
}
