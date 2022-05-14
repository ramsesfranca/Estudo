using Microsoft.AspNetCore.Mvc;
using RF.Estudo.API.Controllers;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels.Categoria;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.API.V1.Controllers
{
    [ApiVersion("1.0")]
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaApplicationService _categoriaApplicationService;

        public CategoriasController(ICategoriaApplicationService categoriaApplicationService)
        {
            this._categoriaApplicationService = categoriaApplicationService;
        }

        [HttpGet, Route("ObterTodos")]
        public async Task<ActionResult<List<FormularioCategoriaViewModel>>> ObterTodos()
        {
            return this.Ok(await this._categoriaApplicationService.SelecionarTodos());
        }

        [HttpPost, Route("Inserir")]
        public async Task<ActionResult<FormularioCategoriaViewModel>> Inserir(FormularioCategoriaViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._categoriaApplicationService.Inserir(modelo);

            return Ok(modelo);
        }
    }
}
