using System;

namespace RF.Estudo.Application.ViewModels
{
    public class HospedagemServicoViewModel : BaseViewModel<Guid>
    {
        public string Nome { get; set; }

        public decimal Valor { get; set; }
    }
}
