﻿using RF.Estudo.Application.ViewModels.Produto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RF.Estudo.Application.Services.Interfaces
{
    public interface IProdutoApplicationService : IBaseApplicationService<Guid, ProdutoViewModel>
    {
        Task<List<ListaProdutoViewModel>> SelecionarTodosAtivos();
    }
}
