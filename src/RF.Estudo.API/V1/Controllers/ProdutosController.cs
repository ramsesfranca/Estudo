using Microsoft.AspNetCore.Mvc;
using RF.Estudo.API.Controllers;
using RF.Estudo.API.V1.Models;
using RF.Estudo.Application.Services.Interfaces;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> Index()
        {
            try
            {
                return new OkObjectResult(await this._produtoApplicationService.SelecionarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
