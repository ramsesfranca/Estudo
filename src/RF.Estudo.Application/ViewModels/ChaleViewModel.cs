using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RF.Estudo.Application.ViewModels
{
    public class ChaleViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Capacidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorAltaEstacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorBaixaEstacao { get; set; }

        public List<ItemViewModel> Itens { get; set; }
    }
}
