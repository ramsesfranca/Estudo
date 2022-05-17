using System.ComponentModel.DataAnnotations;

namespace RF.Estudo.Application.ViewModels.Categoria
{
    public class FormularioCategoriaViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(500, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
        public string Descricao { get; set; }
    }
}
