using Microsoft.AspNetCore.Mvc;
using RF.Estudo.API.Controllers;
using RF.Estudo.Application.Services.Interfaces;
using RF.Estudo.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.API.V1.Controllers
{
    [ApiVersion("1.0")]
    public class HospedagensController : BaseController
    {
        private readonly IHospedagemApplicationService _hospedagemApplicationService;

        public HospedagensController(IHospedagemApplicationService hospedagemApplicationService)
        {
            this._hospedagemApplicationService = hospedagemApplicationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<HospedagemViewModel>>> SelecionarTodos()
        {
            return this.Ok(await this._hospedagemApplicationService.SelecionarTodos());
        }

        [HttpPost]
        public async Task<ActionResult<HospedagemViewModel>> Inserir(HospedagemViewModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._hospedagemApplicationService.Inserir(modelo);

            return Ok(modelo);
        }
    }
}
