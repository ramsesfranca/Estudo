using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RF.Estudo.API.Controllers;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.API.V1.Controllers
{
    [ApiVersion("1.0")]
    public class ClientesController : BaseController
    {
        private readonly IClienteApplicationService _clienteApplicationService;

        public ClientesController(IClienteApplicationService clienteApplicationService)
        {
            this._clienteApplicationService = clienteApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteViewModel>>> ObterTodosAtivos()
        {
            return this.Ok(await this._clienteApplicationService.SelecionarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViewModel>> ObterPorId(Guid id)
        {
            var model = await this._clienteApplicationService.SelecionarPorId(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> Inserir(ClienteViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._clienteApplicationService.Inserir(modelo);

            return Ok(modelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, ClienteViewModel modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await this._clienteApplicationService.Alterar(modelo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this._clienteApplicationService.Existe(p => p.Id.Equals(id)))
                {
                    return NotFound();
                }

                throw;
            }

            return Ok(modelo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteViewModel>> Deletar(Guid id)
        {
            var modelo = await this._clienteApplicationService.SelecionarPorId(id);

            if (modelo == null)
            {
                return NotFound();
            }

            await this._clienteApplicationService.Deletar(modelo);

            return Ok();
        }
    }
}
