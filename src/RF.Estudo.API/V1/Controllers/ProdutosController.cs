using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<ActionResult<List<ListaProdutoViewModel>>> Index()
        {
            try
            {
                return this.Ok(await this._produtoApplicationService.SelecionarTodosAtivos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
