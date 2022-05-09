using Microsoft.AspNetCore.Mvc;
using RF.Estudo.API.Controllers;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.API.V1.Controllers
{
    [ApiVersion("1.0")]
    public class ChalesController : BaseController
    {
        private readonly IChaleApplicationService _chaleApplicationService;

        public ChalesController(IChaleApplicationService ChaleApplicationService)
        {
            this._chaleApplicationService = ChaleApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChaleViewModel>>> SelecionarTodos()
        {
            return this.Ok(await this._chaleApplicationService.SelecionarTodos());
        }

        [HttpPost]
        public async Task<ActionResult<ChaleViewModel>> Inserir(ChaleViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._chaleApplicationService.Inserir(modelo);

            return Ok(modelo);
        }
    }
}
