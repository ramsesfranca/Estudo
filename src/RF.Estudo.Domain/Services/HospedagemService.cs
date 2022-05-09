using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Services
{
    public class HospedagemService : BaseService<Guid, Hospedagem, IHospedagemRepository>, IHospedagemService
    {
        private readonly IServicoService _servicoService;

        public HospedagemService(IUnitOfWork unitOfWork, IHospedagemRepository baseRepository,
            IServicoService servicoService) : base(unitOfWork, baseRepository)
        {
            this._servicoService = servicoService;
        }

        public override async Task Inserir(Hospedagem entidade)
        {
            await this.SelecionarServicos(entidade);

            await base.Inserir(entidade);
        }

        private async Task SelecionarServicos(Hospedagem entidade)
        {
            if (entidade.Servicos.Any())
            {
                var listaServicos = new List<Servico>();

                foreach (var servico in entidade.Servicos.ToList())
                {
                    listaServicos.Add(await this._servicoService.SelecionarPorId(servico.Id));
                }

                entidade.AtualizarServico(listaServicos);
            }
        }
    }
}
