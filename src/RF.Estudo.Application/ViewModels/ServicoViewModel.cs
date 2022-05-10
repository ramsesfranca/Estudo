using System.ComponentModel.DataAnnotations;

namespace RF.Estudo.Application.ViewModels
{
    public class ServicoViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }
    }
}
