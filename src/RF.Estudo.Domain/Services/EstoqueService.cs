using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Data;
using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Services;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEmailService _emailService;

        public EstoqueService(IUnitOfWork unitOfWork, IProdutoRepository produtoRepository,
            IEmailService emailService)
        {
            this._produtoRepository = produtoRepository;
            this._emailService = emailService;
            this._unitOfWork = unitOfWork;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await this._produtoRepository.SelecionarPorId(produtoId);

            if (produto == null)
            {
                return false;
            }

            if (!produto.PossuiEstoque(quantidade))
            {
                return false;
            }

            produto.DebitarEstoque(quantidade);

            // TODO: Parametrizar a quantidade de estoque baixo
            if (produto.Quantidade < 10)
            {
                //await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.Quantidade));
                this._emailService.Enviar("test@mail.com", "Confirm", "Register saved.");
            }

            this._produtoRepository.Alterar(produto);
            await this._unitOfWork.Commit();

            return true;
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await this._produtoRepository.SelecionarPorId(produtoId);

            if (produto == null)
            {
                return false;
            }

            produto.ReporEstoque(quantidade);

            this._produtoRepository.Alterar(produto);
            await this._unitOfWork.Commit();

            return true;
        }
    }
}
