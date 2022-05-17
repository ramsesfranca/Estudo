using RF.Estudo.Domain.Core.Interfaces.Infrastructure.Services;
using RF.Estudo.Domain.Interfaces.Repositorys;
using System.Threading;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Events
{
    public class ProdutoEventHandler //: INotificationHandler<ProdutoAbaixoEstoqueEvent>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEmailService _emailService;

        public ProdutoEventHandler(IProdutoRepository produtoRepository,
            IEmailService emailService)
        {
            this._produtoRepository = produtoRepository;
            this._emailService = emailService;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            //var produto = await this._produtoRepository.SelecionarPorId(mensagem.AggregateId);

            this._emailService.Enviar("test@mail.com", "Aquisição de mais produtos", "Aquisição de mais produtos.");
        }
    }
}
