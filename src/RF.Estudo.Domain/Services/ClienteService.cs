using RF.Estudo.Domain.Core.Interfaces.Infrastructure;
using RF.Estudo.Domain.Entities;
using RF.Estudo.Domain.Interfaces.Repositorys;
using RF.Estudo.Domain.Interfaces.Services;
using RF.Estudo.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Domain.Services
{
    public class ClienteService : BaseService<Guid, Cliente, IClienteRepository>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IUnitOfWork unitOfWork,
            IClienteRepository clienteRepository) : base(unitOfWork, clienteRepository)
        {
            this._clienteRepository = clienteRepository;
        }

        public override async Task Inserir(Cliente entidade)
        {
            if (!ExecutarValidacao(new ClienteValidation(), entidade))
            {
                return;
            }

            if (await this._clienteRepository.Existe(p => p.Nome == entidade.Nome))
            {
                //Notificar("Já existe um Cliente com este nome infomado.");
                return;
            }

            await base.Inserir(entidade);
        }

        public override async Task Alterar(Cliente entidade)
        {
            var cliente = await this.SelecionarPorId(entidade.Id);

            if (cliente != null)
            {
                if (!ExecutarValidacao(new ClienteValidation(), entidade))
                {
                    return;
                }

                if (await this._clienteRepository.Existe(p => p.Nome == entidade.Nome &&
                                                              p.Id != entidade.Id))
                {
                    //Notificar("Já existe um Cliente com este nome infomado.");
                    return;
                }

                cliente.AlterarNome(entidade.Nome);
                cliente.AlterarRg(entidade.Rg);

                await base.Alterar(cliente);
            }
        }

        public override async Task Deletar(Cliente entidade)
        {
            var cliente = await this.SelecionarPorId(entidade.Id);

            if (cliente != null)
            {
                await base.Deletar(cliente);
            }
        }

        public async Task<List<Cliente>> SelecionarTodosOrdenadoPeloNome()
        {
            return await this._clienteRepository.SelecionarTodosOrdenadoPeloNome();
        }
    }
}
