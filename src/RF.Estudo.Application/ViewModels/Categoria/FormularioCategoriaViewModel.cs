using System.ComponentModel.DataAnnotations;

namespace RF.Estudo.Application.ViewModels.Categoria
{
    public class FormularioCategoriaViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }
    }
}
