using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RF.Estudo.API.Controllers;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels.Produto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.API.V1.Controllers
{
    [ApiVersion("1.0")]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoApplicationService _produtoApplicationService;

        public ProdutosController(IProdutoApplicationService produtoApplicationService)
        {
            this._produtoApplicationService = produtoApplicationService;
        }

        [HttpGet, Route("ObterTodosAtivos")]
        public async Task<ActionResult<List<ListaProdutoViewModel>>> ObterTodosAtivos()
        {
            return this.Ok(await this._produtoApplicationService.SelecionarTodosAtivos());
        }

        [HttpGet("{id}"), ActionName("ObterPorId")]
        public async Task<ActionResult<FormularioProdutoViewModel>> ObterPorId(Guid id)
        {
            var model = await this._produtoApplicationService.SelecionarPorId(id);

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        [HttpPost, Route("Inserir")]
        public async Task<ActionResult<FormularioProdutoViewModel>> Inserir(FormularioProdutoViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._produtoApplicationService.Inserir(modelo);

            return Ok(modelo);
        }

        [HttpPut("{id}"), ActionName("Atualizar")]
        public async Task<IActionResult> Atualizar(Guid id, FormularioProdutoViewModel modelo)
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
                await this._produtoApplicationService.Alterar(modelo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this._produtoApplicationService.Existe(p => p.Id.Equals(id)))
                {
                    return NotFound();
                }

                throw;
            }

            return Ok(modelo);
        }

        [HttpDelete("{id}"), ActionName("Deletar")]
        public async Task<ActionResult<FormularioProdutoViewModel>> Deletar(Guid id)
        {
            var modelo = await this._produtoApplicationService.SelecionarPorId(id);

            if (modelo == null)
            {
                return NotFound();
            }

            await this._produtoApplicationService.Deletar(modelo);

            return Ok();
        }

        [HttpPost, Route("AtualizarEstoque")]
        public async Task<ActionResult<FormularioProdutoViewModel>> AtualizarEstoque(Guid id, int quantidade)
        {
            if (quantidade > 0)
            {
                await this._produtoApplicationService.ReporEstoque(id, quantidade);
            }
            else
            {
                await this._produtoApplicationService.DebitarEstoque(id, quantidade);
            }

            return Ok();
        }
    }
}
