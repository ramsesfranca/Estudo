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
    public class ServicosController : BaseController
    {
        private readonly IServicoApplicationService _servicoApplicationService;

        public ServicosController(IServicoApplicationService servicoApplicationService)
        {
            this._servicoApplicationService = servicoApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ServicoViewModel>>> ObterTodosAtivos()
        {
            return this.Ok(await this._servicoApplicationService.SelecionarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServicoViewModel>> ObterPorId(Guid id)
        {
            var model = await this._servicoApplicationService.SelecionarPorId(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<ServicoViewModel>> Inserir(ServicoViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._servicoApplicationService.Inserir(modelo);

            return Ok(modelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, ServicoViewModel modelo)
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
                await this._servicoApplicationService.Alterar(modelo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this._servicoApplicationService.Existe(p => p.Id.Equals(id)))
                {
                    return NotFound();
                }

                throw;
            }

            return Ok(modelo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicoViewModel>> Deletar(Guid id)
        {
            var modelo = await this._servicoApplicationService.SelecionarPorId(id);

            if (modelo == null)
            {
                return NotFound();
            }

            await this._servicoApplicationService.Deletar(modelo);

            return Ok();
        }
    }
}
