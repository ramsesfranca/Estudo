using AutoMapper;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels.Produto;
using RF.Estudo.Domain.Core.Exceptions;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using RF.Estudo.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services
{
    public class ProdutoApplicationService : BaseApplicationService<Guid, Produto, FormularioProdutoViewModel, IProdutoRepository>, IProdutoApplicationService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;

        public ProdutoApplicationService(IMapper mapper, IUnitOfWork unitOfWork,
            IProdutoRepository produtoRepository,
            IEstoqueService estoqueService) : base(mapper, unitOfWork, produtoRepository)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._produtoRepository = produtoRepository;
            this._estoqueService = estoqueService;
        }

        public override async Task Inserir(FormularioProdutoViewModel modelo)
        {
            var produto = this._mapper.Map<Produto>(modelo);

            if (!ExecutarValidacao(new ProdutoValidation(), produto))
            {
                return;
            }

            if (await this._produtoRepository.Existe(p => p.Nome == produto.Nome))
            {
                //Notificar("Já existe um Produto com este nome informado.");
                return;
            }

            this._produtoRepository.Inserir(produto);
            await this._unitOfWork.Commit();
        }

        public override async Task Alterar(FormularioProdutoViewModel modelo)
        {
            var produto = this._mapper.Map<Produto>(modelo);
            var produtoBanco = await this._produtoRepository.SelecionarPorId(produto.Id);

            if (produtoBanco != null)
            {
                if (!ExecutarValidacao(new ProdutoValidation(), produto))
                {
                    return;
                }

                if (await this._produtoRepository.Existe(p => p.Nome == produto.Nome &&
                                                              p.Id != produto.Id))
                {
                    //Notificar("Já existe um Produto com este nome informado.");
                    return;
                }

                produtoBanco.AlterarNome(produto.Nome);
                produtoBanco.AlterarDescricao(produto.Descricao);

                this._produtoRepository.Alterar(produtoBanco);
                await this._unitOfWork.Commit();
            }
        }

        public override async Task Deletar(FormularioProdutoViewModel modelo)
        {
            var produtoBanco = await this._produtoRepository.SelecionarPorId(modelo.Id);

            if (produtoBanco != null)
            {
                this._produtoRepository.Deletar(produtoBanco);
                await this._unitOfWork.Commit();
            }
        }

        public async Task<FormularioProdutoViewModel> DebitarEstoque(Guid id, int quantidade)
        {
            if (!await this._estoqueService.DebitarEstoque(id, quantidade))
            {
                throw new DomainException("Falha ao debitar estoque");
            }

            return _mapper.Map<FormularioProdutoViewModel>(await this._produtoRepository.SelecionarPorId(id));
        }

        public async Task<FormularioProdutoViewModel> ReporEstoque(Guid id, int quantidade)
        {
            if (!await this._estoqueService.ReporEstoque(id, quantidade))
            {
                throw new DomainException("Falha ao repor estoque");
            }

            return _mapper.Map<FormularioProdutoViewModel>(await this._produtoRepository.SelecionarPorId(id));
        }

        public async Task<List<ListaProdutoViewModel>> SelecionarTodosAtivos()
        {
            return this._mapper.Map<List<ListaProdutoViewModel>>(await this._produtoRepository.SelecionarTodosAtivos());
        }
    }
}
