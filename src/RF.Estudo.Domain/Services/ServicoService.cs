using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Services
{
    public class ServicoService : BaseService<Guid, Servico, IServicoRepository>, IServicoService
    {
        private readonly IServicoRepository _servicoRepository;

        public ServicoService(IUnitOfWork unitOfWork,
            IServicoRepository servicoRepository) : base(unitOfWork, servicoRepository)
        {
            this._servicoRepository = servicoRepository;
        }

        public override async Task Inserir(Servico entidade)
        {
            if (await this._servicoRepository.Existe(p => p.Nome == entidade.Nome))
            {
                //Notificar("Já existe um Servico com este nome infomado.");
                return;
            }

            await base.Inserir(entidade);
        }

        public override async Task Alterar(Servico entidade)
        {
            var servico = await this.SelecionarPorId(entidade.Id);

            if (servico != null)
            {
                if (await this._servicoRepository.Existe(p => p.Nome == entidade.Nome &&
                                                              p.Id != entidade.Id))
                {
                    //Notificar("Já existe um Servico com este nome infomado.");
                    return;
                }

                servico.AlterarNome(entidade.Nome);
                servico.AlterarValor(entidade.Valor);

                await base.Alterar(servico);
            }
        }

        public override async Task Deletar(Servico entidade)
        {
            var servico = await this.SelecionarPorId(entidade.Id);

            if (servico != null)
            {
                await base.Deletar(servico);
            }
        }
    }
}
